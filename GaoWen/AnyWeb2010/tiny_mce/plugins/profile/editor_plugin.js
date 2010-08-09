(function() {
    var each = tinymce.each;
    tinymce.create('tinymce.plugins.ProfilePlugin', {
        init: function(ed, url) {
            var t = this;
            t.editor = ed;
            t.url = url;
            ed.addCommand('mceProfile',
            function() {
                ed.windowManager.open({
                    file: url + '/profile.htm',
                    width: 360 + parseInt(ed.getLang('profile.delta_width', 0)),
                    height: 175 + parseInt(ed.getLang('profile.delta_height', 0)),
                    inline: 1
                },
                {
                    plugin_url: url
                });
            });
            ed.addButton('profile', {
                title: 'profile.desc',
                cmd: 'mceProfile'
            });
        },
        getInfo: function() {
            return {
                longname: 'Upload Profile for TinyMce',
                author: 'Earth',
                authorurl: 'http://www.1task.cn/blog/',
                infourl: 'http://www.1task.cn/blog/',
                version: tinymce.majorVersion + "." + tinymce.minorVersion
            };
        }
    });
    tinymce.PluginManager.add('profile', tinymce.plugins.ProfilePlugin);
})();