module.exports = function (grunt) {

    grunt.initConfig({
        pkg: grunt.file.readJSON('package.json'),
        wiredep: {
            target: {
                src: [
                'App_Start/BundleConfig.cs'
                ],
                ignorePath: '..',
                fileTypes: {
                    cs: {
                        block: /(([ \t]*)\/\/\s*bower:*(\S*)\s*)(\n|\r|.)*?(\/\/\s*endbower\s*)/gi,
                        detect: {
                            js: /<script.*src=['"](.+)['"]>/gi,
                            css: /<link.*href=['"](.+)['"]/gi
                        },
                        replace: {
                            js: '.Include("~{{filePath}}")',
                            css: '.Include("~{{filePath}}")',
                        },
                    }
                },
                dependencies: true,
                devDependencies: false,
            }
        },
    });

    grunt.loadNpmTasks('grunt-wiredep');
    grunt.registerTask('default', ['wiredep']);
};