require 'albacore'
require 'fileutils'
require './config/nuget.rb'

# TODO: remove duplicated tasks

# actual version
VERSION = '0.1.3'

# dirs
current_dir = File.dirname(__FILE__)
build_dir = "#{current_dir}/build"
package_dir = "build/package"

# variables
nuget_exe = "tools/nuget/NuGet.exe"

# tasks
task :default => [ :prepare, :compile, ]
task :package => [ :assemblyinfo, :compile, :copy_release, :spec_core, :spec_test, :pack_core, :pack_test ]
task :release => [ :package, :push_core, :push_test ]

task :prepare do
	FileUtils.rm_rf('build')

	Dir.mkdir(build_dir)
	
	Dir.mkdir("#{build_dir}/release_core")
	Dir.mkdir("#{build_dir}/release_core/lib")
	
	Dir.mkdir("#{build_dir}/release_test")
	Dir.mkdir("#{build_dir}/release_test/lib")
	
	Dir.mkdir("#{build_dir}/package")
end

task :assemblyinfo do
	assemblyinfo :assemblyinfo_core do |asm|
	  asm.version = VERSION
	  asm.company_name = "Felice"
	  asm.product_name = "Felice.Core"
	  asm.title = "Felice.Core"
	  asm.description = "Felice Framework"
	  asm.output_file = "#{current_dir}/src/Felice.Core/Properties/AssemblyInfo.cs"
	end

	assemblyinfo :assemblyinfo_test do |asm|
	  asm.version = VERSION
	  asm.company_name = "Felice"
	  asm.product_name = "Felice.TestFramework"
	  asm.title = "Felice.TestFramework"
	  asm.description = "Felice Test Framework"
	  asm.output_file = "#{current_dir}/src/Felice.TestFramework/Properties/AssemblyInfo.cs"
	end
end
	
msbuild :compile do |msb|
  msb.properties :configuration => :Release, :outdir  => "#{build_dir}/bin"
  msb.targets = [ :Clean, :Build ]
  msb.solution = "#{current_dir}/src/Felice.sln"
  msb.verbosity = "minimal"
end

task :copy_release do
	FileUtils.cp "#{build_dir}/bin/Felice.Core.dll", "#{build_dir}/release_core/lib/Felice.Core.dll"
	FileUtils.cp "#{build_dir}/bin/Felice.TestFramework.dll", "#{build_dir}/release_test/lib/Felice.TestFramework.dll"
end

nuspec :spec_core do |nuspec|
	nuspec.id = "Felice"
	nuspec.version = VERSION
	nuspec.authors = "joaofx"
	nuspec.owners = "joaofx"
	nuspec.description = ".net framework that helps you build applications easily"
	nuspec.title = "Felice"
	nuspec.projectUrl = "https://github.com/joaofx/Felice"
	nuspec.output_file = "Felice.nuspec"
	nuspec.working_directory = "#{build_dir}/release_core"

	nuspec.dependency "log4net", "2.0.0"
	nuspec.dependency "structuremap", "2.6.4.1"
	nuspec.dependency "NHibernate", "3.3.3.4001"
	nuspec.dependency "FluentNHibernate", "1.3.0.733"
	nuspec.dependency "NHibernate.Caches.SysCache", "3.3.3.4000"
	nuspec.dependency "Microsoft.AspNet.Mvc", "4.0.30506.0"
end
  
nuspec :spec_test do |nuspec|
	nuspec.id = "Felice.TestFramework"
	nuspec.version = VERSION
	nuspec.authors = "joaofx"
	nuspec.owners = "joaofx"
	nuspec.description = ".net framework that helps you build applications easily"
	nuspec.title = "Felice.TestFramework"
	nuspec.projectUrl = "https://github.com/joaofx/Felice"
	nuspec.output_file = "Felice.TestFramework.nuspec"
	nuspec.working_directory = "#{build_dir}/release_test"

	nuspec.dependency "Felice", "0.1.0"
	nuspec.dependency "NUnit", "2.6.2"
	nuspec.dependency "nbehave.spec.nunit", "0.6.2"
	nuspec.dependency "NSubstitute", "1.6.1.0"
	nuspec.dependency "structuremap.automocking", "2.6.4.1"
end

nugetpack :pack_core do |nuget|
   nuget.command     = "tools/nuget/NuGet.exe"
   nuget.nuspec      = "#{build_dir}/release_core/Felice.nuspec"
   nuget.output      = "build/package"
end

nugetpack :pack_test do |nuget|
   nuget.command     = "tools/nuget/NuGet.exe"
   nuget.nuspec      = "#{build_dir}/release_test/Felice.TestFramework.nuspec"
   nuget.output      = "build/package"
end

nugetpush :push_core do |nuget|

	nuget.command = nuget_exe
	nuget.package = "#{build_dir}/package/Felice.#{VERSION}.nupkg"
	nuget.apikey = API_KEY
	
end

nugetpush :push_test do |nuget|

	nuget.command = nuget_exe
	nuget.package = "#{build_dir}/package/Felice.TestFramework.#{VERSION}.nupkg"
	nuget.apikey = API_KEY
	
end