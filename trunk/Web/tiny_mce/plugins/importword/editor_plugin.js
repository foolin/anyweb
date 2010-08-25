(function() {
    var each = tinymce.each;
    tinymce.create('tinymce.plugins.ImportWordPlugin', {
        init: function(ed, url) {
            var t = this;
            t.editor = ed;
            t.url = url;
            ed.addCommand('mceImportWord',
            function() {
                ed.windowManager.open({
                    file: url + '/importword.htm',
                    width: 380 + parseInt(ed.getLang('importword.delta_width', 0)),
                    height: 160 + parseInt(ed.getLang('importword.delta_height', 0)),
                    inline: 1
                },
                {
                    plugin_url: url
                });
            });
            ed.addButton('importword', {
                title: 'importword.desc',
                cmd: 'mceImportWord'
            });
        },
        getInfo: function() {
            return {
                longname: 'Import Word & Save as Html for TinyMce',
                author: 'Earth',
                authorurl: 'http://www.1task.cn/blog/',
                infourl: 'http://www.1task.cn/blog/',
                version: tinymce.majorVersion + "." + tinymce.minorVersion
            };
        }
    });
    tinymce.PluginManager.add('importword', tinymce.plugins.ImportWordPlugin);
})();