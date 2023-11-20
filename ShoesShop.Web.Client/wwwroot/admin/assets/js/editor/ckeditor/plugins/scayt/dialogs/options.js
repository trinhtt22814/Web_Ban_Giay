﻿CKEDITOR.dialog.add("scaytDialog", function (c) {
    var d = c.scayt, k = '\x3cp\x3e\x3cimg src\x3d"' + d.getLogo() + '" /\x3e\x3c/p\x3e\x3cp\x3e' + d.getLocal("version") + d.getVersion() + "\x3c/p\x3e\x3cp\x3e" + d.getLocal("text_copyrights") + "\x3c/p\x3e", n = CKEDITOR.document, p = { isChanged: function () { return null === this.newLang || this.currentLang === this.newLang ? !1 : !0 }, currentLang: d.getLang(), newLang: null, reset: function () { this.currentLang = d.getLang(); this.newLang = null }, id: "lang" }, k = [{
        id: "options", label: d.getLocal("tab_options"),
        onShow: function () { }, elements: [{ type: "vbox", id: "scaytOptions", children: function () { var b = d.getApplicationConfig(), a = [], c = { "ignore-all-caps-words": "label_allCaps", "ignore-domain-names": "label_ignoreDomainNames", "ignore-words-with-mixed-cases": "label_mixedCase", "ignore-words-with-numbers": "label_mixedWithDigits" }, f; for (f in b) b = { type: "checkbox" }, b.id = f, b.label = d.getLocal(c[f]), a.push(b); return a }(), onShow: function () { this.getChild(); for (var b = c.scayt, a = 0; a < this.getChild().length; a++)this.getChild()[a].setValue(b.getApplicationConfig()[this.getChild()[a].id]) } }]
    },
    {
        id: "langs", label: d.getLocal("tab_languages"), elements: [{
            id: "leftLangColumn", type: "vbox", align: "left", widths: ["100"], children: [{
                type: "html", id: "langBox", style: "overflow: hidden; white-space: normal;margin-bottom:15px;", html: '\x3cdiv\x3e\x3cdiv style\x3d"float:left;width:45%;margin-left:5px;" id\x3d"left-col-' + c.name + '" class\x3d"scayt-lang-list"\x3e\x3c/div\x3e\x3cdiv style\x3d"float:left;width:45%;margin-left:15px;" id\x3d"right-col-' + c.name + '" class\x3d"scayt-lang-list"\x3e\x3c/div\x3e\x3c/div\x3e',
                onShow: function () { var b = c.scayt.getLang(); n.getById("scaytLang_" + c.name + "_" + b).$.checked = !0 }
            }, {
                type: "html", id: "graytLanguagesHint", html: '\x3cdiv style\x3d"margin:5px auto; width:95%;white-space:normal;" id\x3d"' + c.name + 'graytLanguagesHint"\x3e\x3cspan style\x3d"width:10px;height:10px;display: inline-block; background:#02b620;vertical-align:top;margin-top:2px;"\x3e\x3c/span\x3e - This languages are supported by Grammar As You Type(GRAYT).\x3c/div\x3e', onShow: function () {
                    var b = n.getById(c.name + "graytLanguagesHint");
                    c.config.grayt_autoStartup || (b.$.style.display = "none")
                }
            }]
        }]
    }, {
        id: "dictionaries", label: d.getLocal("tab_dictionaries"), elements: [{
            type: "vbox", id: "rightCol_col__left", children: [{ type: "html", id: "dictionaryNote", html: "" }, {
                type: "text", id: "dictionaryName", label: d.getLocal("label_fieldNameDic") || "Dictionary name", onShow: function (b) {
                    var a = b.sender, h = c.scayt; b = SCAYT.prototype.UILib; var f = a.getContentElement("dictionaries", "dictionaryName").getInputElement().$; h.isLicensed() || (f.disabled = !0, b.css(f, { cursor: "not-allowed" }));
                    setTimeout(function () { a.getContentElement("dictionaries", "dictionaryNote").getElement().setText(""); null != h.getUserDictionaryName() && "" != h.getUserDictionaryName() && a.getContentElement("dictionaries", "dictionaryName").setValue(h.getUserDictionaryName()) }, 0)
                }
            }, {
                type: "hbox", id: "udButtonsHolder", align: "left", widths: ["auto"], style: "width:auto;", children: [{
                    type: "button", id: "createDic", label: d.getLocal("btn_createDic"), title: d.getLocal("btn_createDic"), onLoad: function () {
                        this.getDialog(); var b = c.scayt, a =
                            SCAYT.prototype.UILib, h = this.getElement().$, f = this.getElement().getChild(0).$; b.isLicensed() || (a.css(h, { cursor: "not-allowed" }), a.css(f, { cursor: "not-allowed" }))
                    }, onClick: function () {
                        var b = this.getDialog(), a = g, h = c.scayt, f = b.getContentElement("dictionaries", "dictionaryName").getValue(); h.isLicensed() && h.createUserDictionary(f, function (e) { e.error || a.toggleDictionaryState.call(b, "dictionaryState"); e.dialog = b; e.command = "create"; e.name = f; c.fire("scaytUserDictionaryAction", e) }, function (a) {
                            a.dialog = b; a.command =
                                "create"; a.name = f; c.fire("scaytUserDictionaryActionError", a)
                        })
                    }
                }, {
                    type: "button", id: "restoreDic", label: d.getLocal("btn_connectDic"), title: d.getLocal("btn_connectDic"), onLoad: function () { this.getDialog(); var b = c.scayt, a = SCAYT.prototype.UILib, h = this.getElement().$, f = this.getElement().getChild(0).$; b.isLicensed() || (a.css(h, { cursor: "not-allowed" }), a.css(f, { cursor: "not-allowed" })) }, onClick: function () {
                        var b = this.getDialog(), a = c.scayt, h = g, f = b.getContentElement("dictionaries", "dictionaryName").getValue(); a.isLicensed() &&
                            a.restoreUserDictionary(f, function (a) { a.dialog = b; a.error || h.toggleDictionaryState.call(b, "dictionaryState"); a.command = "restore"; a.name = f; c.fire("scaytUserDictionaryAction", a) }, function (a) { a.dialog = b; a.command = "restore"; a.name = f; c.fire("scaytUserDictionaryActionError", a) })
                    }
                }, {
                    type: "button", id: "disconnectDic", label: d.getLocal("btn_disconnectDic"), title: d.getLocal("btn_disconnectDic"), onClick: function () {
                        var b = this.getDialog(), a = c.scayt, h = g, f = b.getContentElement("dictionaries", "dictionaryName"), e = f.getValue();
                        a.isLicensed() && (a.disconnectFromUserDictionary({}), f.setValue(""), h.toggleDictionaryState.call(b, "initialState"), c.fire("scaytUserDictionaryAction", { dialog: b, command: "disconnect", name: e }))
                    }
                }, {
                    type: "button", id: "removeDic", label: d.getLocal("btn_deleteDic"), title: d.getLocal("btn_deleteDic"), onClick: function () {
                        var b = this.getDialog(), a = c.scayt, h = g, f = b.getContentElement("dictionaries", "dictionaryName"), e = f.getValue(); a.isLicensed() && a.removeUserDictionary(e, function (a) {
                            f.setValue(""); a.error || h.toggleDictionaryState.call(b,
                                "initialState"); a.dialog = b; a.command = "remove"; a.name = e; c.fire("scaytUserDictionaryAction", a)
                        }, function (a) { a.dialog = b; a.command = "remove"; a.name = e; c.fire("scaytUserDictionaryActionError", a) })
                    }
                }, {
                    type: "button", id: "renameDic", label: d.getLocal("btn_renameDic"), title: d.getLocal("btn_renameDic"), onClick: function () {
                        var b = this.getDialog(), a = c.scayt, h = b.getContentElement("dictionaries", "dictionaryName").getValue(); a.isLicensed() && a.renameUserDictionary(h, function (a) {
                            a.dialog = b; a.command = "rename"; a.name = h; c.fire("scaytUserDictionaryAction",
                                a)
                        }, function (a) { a.dialog = b; a.command = "rename"; a.name = h; c.fire("scaytUserDictionaryActionError", a) })
                    }
                }, { type: "button", id: "editDic", label: d.getLocal("btn_goToDic"), title: d.getLocal("btn_goToDic"), onLoad: function () { this.getDialog() }, onClick: function () { var b = this.getDialog(), a = b.getContentElement("dictionaries", "addWordField"); g.clearWordList.call(b); a.setValue(""); g.getUserDictionary.call(b); g.toggleDictionaryState.call(b, "wordsState") } }]
            }, {
                type: "hbox", id: "dicInfo", align: "left", children: [{
                    type: "html",
                    id: "dicInfoHtml", html: '\x3cdiv id\x3d"dic_info_editor1" style\x3d"margin:5px auto; width:95%;white-space:normal;"\x3e' + (c.scayt.isLicensed && c.scayt.isLicensed() ? d.getLocal("text_descriptionDicForPaid") : d.getLocal("text_descriptionDicForFree")) + "\x3c/div\x3e"
                }]
            }, {
                id: "addWordAction", type: "hbox", style: "width: 100%; margin-bottom: 0;", widths: ["40%", "60%"], children: [{ id: "addWord", type: "vbox", style: "min-width: 150px;", children: [{ type: "text", id: "addWordField", label: "Add word", maxLength: "64" }] }, {
                    id: "addWordButtons",
                    type: "vbox", style: "margin-top: 20px;", children: [{
                        type: "hbox", id: "addWordButton", align: "left", children: [{
                            type: "button", id: "addWord", label: d.getLocal("btn_addWord"), title: d.getLocal("btn_addWord"), onClick: function () {
                                var b = this.getDialog(), a = c.scayt, h = b.getContentElement("dictionaries", "itemList"), f = b.getContentElement("dictionaries", "addWordField"), e = f.getValue(), d = a.getOption("wordBoundaryRegex"), g = this; e && (-1 !== e.search(d) ? c.fire("scaytUserDictionaryAction", {
                                    dialog: b, command: "wordWithBannedSymbols",
                                    name: e, error: !0
                                }) : h.inChildren(e) ? (f.setValue(""), c.fire("scaytUserDictionaryAction", { dialog: b, command: "wordAlreadyAdded", name: e })) : (this.disable(), a.addWordToUserDictionary(e, function (a) { a.error || (f.setValue(""), h.addChild(e, !0)); a.dialog = b; a.command = "addWord"; a.name = e; g.enable(); c.fire("scaytUserDictionaryAction", a) }, function (a) { a.dialog = b; a.command = "addWord"; a.name = e; g.enable(); c.fire("scaytUserDictionaryActionError", a) })))
                            }
                        }, {
                            type: "button", id: "backToDic", label: d.getLocal("btn_dictionaryPreferences"),
                            title: d.getLocal("btn_dictionaryPreferences"), align: "right", onClick: function () { var b = this.getDialog(), a = c.scayt; null != a.getUserDictionaryName() && "" != a.getUserDictionaryName() ? g.toggleDictionaryState.call(b, "dictionaryState") : g.toggleDictionaryState.call(b, "initialState") }
                        }]
                    }]
                }]
            }, {
                id: "wordsHolder", type: "hbox", style: "width: 100%; height: 170px; margin-bottom: 0;", children: [{
                    type: "scaytItemList", id: "itemList", align: "left", style: "width: 100%; height: 170px; overflow: auto", onClick: function (b) {
                        b = b.data.$;
                        var a = c.scayt, h = SCAYT.prototype.UILib, f = h.parent(b.target)[0], e = h.attr(f, "data-cke-scayt-ud-word"), d = this.getDialog(), g = d.getContentElement("dictionaries", "itemList"), m = this; h.hasClass(b.target, "cke_scaytItemList_remove") && !this.isBlocked() && (this.block(), a.deleteWordFromUserDictionary(e, function (a) { a.error || g.removeChild(f, e); m.unblock(); a.dialog = d; a.command = "deleteWord"; a.name = e; c.fire("scaytUserDictionaryAction", a) }, function (a) {
                            m.unblock(); a.dialog = d; a.command = "deleteWord"; a.name = e; c.fire("scaytUserDictionaryActionError",
                                a)
                        }))
                    }
                }]
            }]
        }]
    }, { id: "about", label: d.getLocal("tab_about"), elements: [{ type: "html", id: "about", style: "margin: 5px 5px;", html: '\x3cdiv\x3e\x3cdiv id\x3d"scayt_about_"\x3e' + k + "\x3c/div\x3e\x3c/div\x3e" }] }]; c.on("scaytUserDictionaryAction", function (b) {
        var a = SCAYT.prototype.UILib, c = b.data.dialog, f = c.getContentElement("dictionaries", "dictionaryNote").getElement(), e = b.editor.scayt, d; void 0 === b.data.error ? (d = e.getLocal("message_success_" + b.data.command + "Dic"), d = d.replace("%s", b.data.name), f.setText(d), a.css(f.$,
            { color: "blue" })) : ("" === b.data.name ? f.setText(e.getLocal("message_info_emptyDic")) : (d = e.getLocal("message_error_" + b.data.command + "Dic"), d = d.replace("%s", b.data.name), f.setText(d)), a.css(f.$, { color: "red" }), null != e.getUserDictionaryName() && "" != e.getUserDictionaryName() ? c.getContentElement("dictionaries", "dictionaryName").setValue(e.getUserDictionaryName()) : c.getContentElement("dictionaries", "dictionaryName").setValue(""))
    }); c.on("scaytUserDictionaryActionError", function (b) {
        var a = SCAYT.prototype.UILib,
            c = b.data.dialog, d = c.getContentElement("dictionaries", "dictionaryNote").getElement(), e = b.editor.scayt, g; "" === b.data.name ? d.setText(e.getLocal("message_info_emptyDic")) : (g = e.getLocal("message_error_" + b.data.command + "Dic"), g = g.replace("%s", b.data.name), d.setText(g)); a.css(d.$, { color: "red" }); null != e.getUserDictionaryName() && "" != e.getUserDictionaryName() ? c.getContentElement("dictionaries", "dictionaryName").setValue(e.getUserDictionaryName()) : c.getContentElement("dictionaries", "dictionaryName").setValue("")
    });
    var g = {
        title: d.getLocal("text_title"), resizable: CKEDITOR.DIALOG_RESIZE_BOTH, minWidth: "moono-lisa" == (CKEDITOR.skinName || c.config.skin) ? 450 : 340, minHeight: 300, onLoad: function () { if (0 != c.config.scayt_uiTabs[1]) { var b = g, a = b.getLangBoxes.call(this); this.getContentElement("dictionaries", "addWordField"); a.getParent().setStyle("white-space", "normal"); b.renderLangList(a); this.definition.minWidth = this.getSize().width; this.resize(this.definition.minWidth, this.definition.minHeight) } }, onCancel: function () { p.reset() },
        onHide: function () { c.unlockSelection() }, onShow: function () { c.fire("scaytDialogShown", this); if (0 != c.config.scayt_uiTabs[2]) { var b = this.getContentElement("dictionaries", "addWordField"); g.clearWordList.call(this); b.setValue(""); g.getUserDictionary.call(this); g.toggleDictionaryState.call(this, "wordsState") } }, onOk: function () { var b = g, a = c.scayt; this.getContentElement("options", "scaytOptions"); b = b.getChangedOption.call(this); a.commitOption({ changedOptions: b }) }, toggleDictionaryButtons: function (b) {
            var a = this.getContentElement("dictionaries",
                "existDic").getElement().getParent(), c = this.getContentElement("dictionaries", "notExistDic").getElement().getParent(); b ? (a.show(), c.hide()) : (a.hide(), c.show())
        }, getChangedOption: function () { var b = {}; if (1 == c.config.scayt_uiTabs[0]) for (var a = this.getContentElement("options", "scaytOptions").getChild(), d = 0; d < a.length; d++)a[d].isChanged() && (b[a[d].id] = a[d].getValue()); p.isChanged() && (b[p.id] = c.config.scayt_sLang = p.currentLang = p.newLang); return b }, buildRadioInputs: function (b, a, d) {
            var f = new CKEDITOR.dom.element("div"),
                e = "scaytLang_" + c.name + "_" + a, g = CKEDITOR.dom.element.createFromHtml('\x3cinput id\x3d"' + e + '" type\x3d"radio"  value\x3d"' + a + '" name\x3d"scayt_lang" /\x3e'), k = new CKEDITOR.dom.element("label"), m = c.scayt; f.setStyles({ "white-space": "normal", position: "relative", "padding-bottom": "2px" }); g.on("click", function (a) { p.newLang = a.sender.getValue() }); k.appendText(b); k.setAttribute("for", e); d && c.config.grayt_autoStartup && k.setStyles({ color: "#02b620" }); f.append(g); f.append(k); a === m.getLang() && (g.setAttribute("checked",
                    !0), g.setAttribute("defaultChecked", "defaultChecked")); return f
        }, renderLangList: function (b) {
            var a = b.find("#left-col-" + c.name).getItem(0); b = b.find("#right-col-" + c.name).getItem(0); var h = d.getScaytLangList(), f = d.getGraytLangList(), e = {}, g = [], k = 0, m = !1, l; for (l in h.ltr) e[l] = h.ltr[l]; for (l in h.rtl) e[l] = h.rtl[l]; for (l in e) g.push([l, e[l]]); g.sort(function (a, b) { var c = 0; a[1] > b[1] ? c = 1 : a[1] < b[1] && (c = -1); return c }); e = {}; for (m = 0; m < g.length; m++)e[g[m][0]] = g[m][1]; g = Math.round(g.length / 2); for (l in e) k++, m = l in
                f.ltr || l in f.rtl, this.buildRadioInputs(e[l], l, m).appendTo(k <= g ? a : b)
        }, getLangBoxes: function () { return this.getContentElement("langs", "langBox").getElement() }, toggleDictionaryState: function (b) {
            var a = this.getContentElement("dictionaries", "dictionaryName").getElement().getParent(), c = this.getContentElement("dictionaries", "udButtonsHolder").getElement().getParent(), d = this.getContentElement("dictionaries", "createDic").getElement().getParent(), e = this.getContentElement("dictionaries", "restoreDic").getElement().getParent(),
                g = this.getContentElement("dictionaries", "disconnectDic").getElement().getParent(), k = this.getContentElement("dictionaries", "removeDic").getElement().getParent(), m = this.getContentElement("dictionaries", "renameDic").getElement().getParent(), l = this.getContentElement("dictionaries", "dicInfo").getElement().getParent(), p = this.getContentElement("dictionaries", "addWordAction").getElement().getParent(), n = this.getContentElement("dictionaries", "wordsHolder").getElement().getParent(); switch (b) {
                    case "initialState": a.show();
                        c.show(); d.show(); e.show(); g.hide(); k.hide(); m.hide(); l.show(); p.hide(); n.hide(); break; case "wordsState": a.hide(); c.hide(); l.hide(); p.show(); n.show(); break; case "dictionaryState": a.show(), c.show(), d.hide(), e.hide(), g.show(), k.show(), m.show(), l.show(), p.hide(), n.hide()
                }
        }, clearWordList: function () { this.getContentElement("dictionaries", "itemList").removeAllChild() }, getUserDictionary: function () { var b = this; c.scayt.getUserDictionary("", function (a) { a.error || g.renderItemList.call(b, a.wordlist) }) }, renderItemList: function (b) {
            for (var a =
                this.getContentElement("dictionaries", "itemList"), c = 0; c < b.length; c++)a.addChild(b[c])
        }, contents: function (b, a) { var c = [], d = a.config.scayt_uiTabs; if (d) { for (var e in d) 1 == d[e] && c.push(b[e]); c.push(b[b.length - 1]) } else return b; return c }(k, c)
    }; return g
});
CKEDITOR.tools.extend(CKEDITOR.ui.dialog, { scaytItemList: function (c, d, k) { if (arguments.length) { var n = this; c.on("load", function () { n.getElement().on("click", function (c) { }) }); CKEDITOR.ui.dialog.uiElement.call(this, c, d, k, "", null, null, function () { var c = ['\x3cp class\x3d"cke_dialog_ui_', d.type, '"']; d.style && c.push('style\x3d"' + d.style + '" '); c.push("\x3e"); c.push("\x3c/p\x3e"); return c.join("") }) } } });
CKEDITOR.ui.dialog.scaytItemList.prototype = CKEDITOR.tools.extend(new CKEDITOR.ui.dialog.uiElement, {
    children: [], blocked: !1, addChild: function (c, d) {
        var k = new CKEDITOR.dom.element("p"), n = new CKEDITOR.dom.element("a"), p = this.getElement().getChildren().getItem(0); this.children.push(c); k.addClass("cke_scaytItemList-child"); k.setAttribute("data-cke-scayt-ud-word", c); k.appendText(c); n.addClass("cke_scaytItemList_remove"); n.addClass("cke_dialog_close_button"); n.setAttribute("href", "javascript:void(0)"); k.append(n);
        p.append(k, d ? !0 : !1)
    }, inChildren: function (c) { return SCAYT.prototype.Utils.inArray(this.children, c) }, removeChild: function (c, d) { this.children.splice(SCAYT.prototype.Utils.indexOf(this.children, d), 1); this.getElement().getChildren().getItem(0).$.removeChild(c) }, removeAllChild: function () { this.children = []; this.getElement().getChildren().getItem(0).setHtml("") }, block: function () { this.blocked = !0 }, unblock: function () { this.blocked = !1 }, isBlocked: function () { return this.blocked }
});
(function () { commonBuilder = { build: function (c, d, k) { return new CKEDITOR.ui.dialog[d.type](c, d, k) } }; CKEDITOR.dialog.addUIElement("scaytItemList", commonBuilder) })();