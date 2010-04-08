/**
 * $Id: editor_plugin_src.js 520 2008-01-07 16:30:32Z spocke $
 *
 * @author Earth
 * @copyright Copyright ?2004-2008, Moxiecode Systems AB, All rights reserved.
 */
 
(function() {
	tinymce.create('tinymce.plugins.PageseparatorPlugin', {
		init : function(ed, url) {
			// Register commands
			ed.addCommand('mcePageseparator', function() {
				// Internal image object like a flash placeholder
				if (ed.dom.getAttrib(ed.selection.getNode(), 'class').indexOf('mceItem') != -1)
					return;

		        el = ed.selection.getNode();

		        if (el && el.nodeName == 'DIV') {
			        ed.dom.setAttrib('class', 'page_separator', '');
		        } else {
			        ed.execCommand('mceInsertContent', false, '<div class="page_separator" />', {skip_undo : 1});
			        ed.undoManager.add();
		        }
                /*
				ed.windowManager.open({
					file : url + '/image.htm',
					width : 480 + parseInt(ed.getLang('advimage.delta_width', 0)),
					height : 385 + parseInt(ed.getLang('advimage.delta_height', 0)),
					inline : 1
				}, {
					plugin_url : url
				});*/
			});

			// Register buttons
			ed.addButton('pageseparator', {
				title : 'pageseparator.desc',
				cmd : 'mcePageseparator'
			});
		},

		getInfo : function() {
			return {
				longname : 'Page separator',
				author : 'Moxiecode Systems AB',
				authorurl : 'http://tinymce.moxiecode.com',
				infourl : 'http://wiki.moxiecode.com/index.php/TinyMCE:Plugins/advimage',
				version : tinymce.majorVersion + "." + tinymce.minorVersion
			};
		}
	});

	// Register plugin
	tinymce.PluginManager.add('pageseparator', tinymce.plugins.PageseparatorPlugin);
})();