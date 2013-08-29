require 'albacore'
require 'fileutils'
require './config/nuget.rb'

# actual version
VERSION = "0.1.4"
AUTHORS = "joaofx"
DESCRIPTION = ".net framework that helps you build applications easily"
PROJECT_URL = "https://github.com/joaofx/Felice"
COMPANY = "Felice"

# dirs
current_dir = File.dirname(__FILE__)
build_dir = "#{current_dir}/build"
package_dir = "build/package"
release_dir = "build/release"

# variables
nuget_exe = "tools/nuget/NuGet.exe"

# tasks
task :default => [ :prepare, :compile, ]
task :package => [ :asm, :compile, :copy_release, :spec, :pack ]
task :publish => [ :package, :push ]

task :prepare do
	FileUtils.rm_rf('build')

	Dir.mkdir(build_dir)	
    Dir.mkdir(release_dir)
	Dir.mkdir(package_dir)
end

# create assembly info
task :asm => [ :asm_core, :asm_data, :asm_mvc, :asm_test ]

assemblyinfo :asm_core do |asm|
    name = "Felice.Core"
    asm.version = VERSION
    asm.company_name = COMPANY
    asm.product_name = name
    asm.title = name
    asm.description = DESCRIPTION
    asm.output_file = "#{current_dir}/src/#{name}/Properties/AssemblyInfo.cs"
end

assemblyinfo :asm_data do |asm|
    name = "Felice.Data"
	asm.version = VERSION
	asm.company_name = COMPANY
	asm.product_name = name
	asm.title = name
	asm.description = DESCRIPTION
	asm.output_file = "#{current_dir}/src/#{name}/Properties/AssemblyInfo.cs"
end
    
assemblyinfo :asm_mvc do |asm|
    name = "Felice.Mvc"
	asm.version = VERSION
	asm.company_name = COMPANY
	asm.product_name = name
	asm.title = name
	asm.description = DESCRIPTION
	asm.output_file = "#{current_dir}/src/#{name}/Properties/AssemblyInfo.cs"
end
    
assemblyinfo :asm_test do |asm|
    name = "Felice.TestFramework"
	asm.version = VERSION
	asm.company_name = COMPANY
	asm.product_name = name
	asm.title = name
	asm.description = DESCRIPTION
	asm.output_file = "#{current_dir}/src/#{name}/Properties/AssemblyInfo.cs"
end

msbuild :compile do |msb|
  msb.properties :configuration => :Release, :outdir  => "#{build_dir}/bin"
  msb.targets = [ :Clean, :Build ]
  msb.solution = "#{current_dir}/src/Felice.sln"
  msb.verbosity = "minimal"
end

task :copy_release do
    FileUtils.cp "#{build_dir}/bin/Felice.Core.dll", "#{release_dir}/Felice.Core.dll"
    FileUtils.cp "#{build_dir}/bin/Felice.Data.dll", "#{release_dir}/Felice.Data.dll"
    FileUtils.cp "#{build_dir}/bin/Felice.Mvc.dll", "#{release_dir}/Felice.Mvc.dll"
    FileUtils.cp "#{build_dir}/bin/Felice.TestFramework.dll", "#{release_dir}/Felice.TestFramework.dll"
end

# create nuspec file
task :spec => [ :spec_core, :spec_data, :spec_mvc, :spec_test ]

nuspec :spec_core do |nuspec|
    nuspec.id = "Felice"
    nuspec.version = VERSION
    nuspec.authors = AUTHORS
    nuspec.description = DESCRIPTION
    nuspec.projectUrl = PROJECT_URL
    nuspec.working_directory = release_dir
    nuspec.output_file = "Felice.nuspec"
        
    nuspec.file "Felice.Core.dll"      
       
    nuspec.dependency "log4net", "2.0.0"
    nuspec.dependency "structuremap", "2.6.4.1"
        
    nuspec.framework_assembly "System.Web", "net40"
end
    
nuspec :spec_data do |nuspec|
    nuspec.id = "Felice.Data"
    nuspec.version = VERSION
    nuspec.authors = AUTHORS
    nuspec.description = DESCRIPTION
    nuspec.projectUrl = PROJECT_URL
    nuspec.working_directory = release_dir
    nuspec.output_file = "Felice.Data.nuspec"
        
    nuspec.file "Felice.Data.dll"      
       
    nuspec.dependency "Felice", "[#{VERSION}]"
    nuspec.dependency "NHibernate", "3.3.3.4001"
    nuspec.dependency "NHibernate.Caches.SysCache", "3.3.3.4000"
    nuspec.dependency "FluentNHibernate", "1.3.0.733"
    nuspec.dependency "FluentMigrator", "[1.1.1.0]"
    nuspec.dependency "FluentMigrator.Tools", "[1.1.1.0]"
        
    nuspec.framework_assembly "System.Data", "net40"
end
    
nuspec :spec_mvc do |nuspec|
    nuspec.id = "Felice.Mvc"
    nuspec.version = VERSION
    nuspec.authors = AUTHORS
    nuspec.description = DESCRIPTION
    nuspec.projectUrl = PROJECT_URL
    nuspec.working_directory = release_dir
    nuspec.output_file = "Felice.Mvc.nuspec"
        
    nuspec.file "Felice.Mvc.dll"
       
    nuspec.dependency "Felice", "[#{VERSION}]"
    nuspec.dependency "Felice.Data", "[#{VERSION}]"
    nuspec.dependency "Microsoft.AspNet.Mvc", "4.0.30506.0"
        
    nuspec.framework_assembly "System.Web", "net40"
end    
    
nuspec :spec_test do |nuspec|
    nuspec.id = "Felice.TestFramework"
    nuspec.version = VERSION
    nuspec.authors = AUTHORS
    nuspec.description = DESCRIPTION
    nuspec.projectUrl = PROJECT_URL
    nuspec.working_directory = release_dir
    nuspec.output_file = "Felice.TestFramework.nuspec"
        
    nuspec.file "Felice.TestFramework.dll"
       
    nuspec.dependency "Felice", "[#{VERSION}]"
    nuspec.dependency "Felice.Data", "[#{VERSION}]"
    nuspec.dependency "Felice.Mvc", "[#{VERSION}]"
	nuspec.dependency "NUnit", "2.6.2"
	nuspec.dependency "nbehave.spec.nunit", "0.6.2"
	nuspec.dependency "NSubstitute", "1.6.1.0"
	nuspec.dependency "structuremap.automocking", "2.6.4.1"
end    

# generate nupkg
task :pack => [ :pack_core, :pack_data, :pack_mvc, :pack_test ]

nugetpack :pack_core do |nuget|
   nuget.command     = nuget_exe
   nuget.nuspec      = "#{release_dir}/Felice.nuspec"
   nuget.output      = "#{package_dir}"
end

nugetpack :pack_data do |nuget|
   nuget.command     = nuget_exe
   nuget.nuspec      = "#{release_dir}/Felice.Data.nuspec"
   nuget.output      = "#{package_dir}"
end

nugetpack :pack_mvc do |nuget|
   nuget.command     = nuget_exe
   nuget.nuspec      = "#{release_dir}/Felice.Mvc.nuspec"
   nuget.output      = "#{package_dir}"
end

nugetpack :pack_test do |nuget|
   nuget.command     = nuget_exe
   nuget.nuspec      = "#{release_dir}/Felice.TestFramework.nuspec"
   nuget.output      = "#{package_dir}"
end

# publish packages
task :push => [ :push_core, :push_data, :push_mvc, :push_test ]

nugetpush :push_core do |nuget|
	nuget.command = nuget_exe
	nuget.package = "#{build_dir}/package/Felice.#{VERSION}.nupkg"
	nuget.apikey = API_KEY	
end

nugetpush :push_data do |nuget|
	nuget.command = nuget_exe
	nuget.package = "#{build_dir}/package/Felice.Data.#{VERSION}.nupkg"
	nuget.apikey = API_KEY	
end

nugetpush :push_mvc do |nuget|
	nuget.command = nuget_exe
	nuget.package = "#{build_dir}/package/Felice.Mvc.#{VERSION}.nupkg"
	nuget.apikey = API_KEY	
end

nugetpush :push_test do |nuget|
	nuget.command = nuget_exe
	nuget.package = "#{build_dir}/package/Felice.TestFramework.#{VERSION}.nupkg"
	nuget.apikey = API_KEY	
end