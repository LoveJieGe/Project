if(typeof(LigerUIManagers)=="undefined"){LigerUIManagers={}}(function(A){A.fn.ligerGetTabManager=function(){return LigerUIManagers[this[0].id+"_Tab"]};A.fn.ligerRemoveTabManager=function(){return this.each(function(){LigerUIManagers[this.id+"_Tab"]=null})};A.fn.ligerTab=function(B){B=A.extend({height:null,heightDiff:0,changeHeightOnResize:false},B||{});return this.each(function(){if(this.usedTab){return}if(A(this).hasClass("l-hidden")){return}var D={setTabButton:function(){var E=0;A("li",D.tab.links.ul).each(function(){E+=A(this).width()+2});var F=D.tab.width();if(E>F){D.tab.links.append('<div class="l-tab-links-left"></div><div class="l-tab-links-right"></div>');D.setTabButtonEven();return true}else{D.tab.links.ul.animate({left:0});A(".l-tab-links-left,.l-tab-links-right",D.tab.links).remove();return false}},setTabButtonEven:function(){A(".l-tab-links-left",D.tab.links).hover(function(){A(this).addClass("l-tab-links-left-over")},function(){A(this).removeClass("l-tab-links-left-over")}).click(function(){D.moveToPrevTabItem()});A(".l-tab-links-right",D.tab.links).hover(function(){A(this).addClass("l-tab-links-right-over")},function(){A(this).removeClass("l-tab-links-right-over")}).click(function(){D.moveToNextTabItem()})},moveToPrevTabItem:function(){var H=A(".l-tab-links-left",D.tab.links).width();var E=new Array();A("li",D.tab.links).each(function(J,K){var I=-1*H;if(J>0){I=parseInt(E[J-1])+A(this).prev().width()+2}E.push(I)});var G=-1*parseInt(D.tab.links.ul.css("left"));for(var F=0;F<E.length-1;F++){if(E[F]<G&&E[F+1]>=G){D.tab.links.ul.animate({left:-1*parseInt(E[F])});return}}},moveToNextTabItem:function(){var G=A(".l-tab-links-right",D.tab).width();var L=0;var J=A("li",D.tab.links.ul);J.each(function(){L+=A(this).width()+2});var H=D.tab.width();var K=new Array();for(var E=J.length-1;E>=0;E--){var F=L-H+G+2;if(E!=J.length-1){F=parseInt(K[J.length-2-E])-A(J[E+1]).width()-2}K.push(F)}var I=-1*parseInt(D.tab.links.ul.css("left"));for(var E=1;E<K.length;E++){if(K[E]<=I&&K[E-1]>I){D.tab.links.ul.animate({left:-1*parseInt(K[E-1])});return}}},selectTabItem:function(E){D.selectedTabId=E;A("> .l-tab-content-item[tabid="+E+"]",D.tab.content).show().siblings().hide();A("li[tabid="+E+"]",D.tab.links.ul).addClass("l-selected").siblings().removeClass("l-selected")},moveToLastTabItem:function(){var E=0;A("li",D.tab.links.ul).each(function(){E+=A(this).width()+2});var F=D.tab.width();if(E>F){var G=A(".l-tab-links-right",D.tab.links).width();D.tab.links.ul.animate({left:-1*(E-F+G+2)})}},isTabItemExist:function(E){return A("li[tabid="+E+"]",D.tab.links.ul).length>0},addTabItem:function(E){var F=E.tabid;if(F==undefined){F=D.getNewTabid()}var I=E.url;var K=E.text;var H=E.showClose;var J=E.height;if(D.isTabItemExist(F)){D.selectTabItem(F);return}var L=A("<li><a></a><div class='l-tab-links-item-left'></div><div class='l-tab-links-item-right'></div><div class='l-tab-links-item-close'></div></li>");var M=A("<div class='l-tab-content-item'><iframe frameborder='0'></iframe></div>");if(D.makeFullHeight){var G=D.tab.height()-D.tab.links.height();M.height(G)}L.attr("tabid",F);M.attr("tabid",F);A("iframe",M).attr("name",F);if(H==undefined){H=true}if(H==false){A(".l-tab-links-item-close",L).remove()}if(K==undefined){K=F}if(J){M.height(J)}A("a",L).text(K);A("iframe",M).attr("src",I);D.tab.links.ul.append(L);D.tab.content.append(M);D.selectTabItem(F);if(D.setTabButton()){D.moveToLastTabItem()}D.addTabItemEvent(L)},addTabItemEvent:function(E){E.click(function(){var F=A(this).attr("tabid");D.selectTabItem(F)});A(".l-tab-links-item-close",E).hover(function(){A(this).addClass("l-tab-links-item-close-over")},function(){A(this).removeClass("l-tab-links-item-close-over")}).click(function(){var F=A(this).parent().attr("tabid");D.removeTabItem(F)})},removeTabItem:function(E){var F=A("li[tabid="+E+"]",D.tab.links.ul).hasClass("l-selected");if(F){A(".l-tab-content-item[tabid="+E+"]",D.tab.content).prev().show();A("li[tabid="+E+"]",D.tab.links.ul).prev().addClass("l-selected").siblings().removeClass("l-selected")}A(".l-tab-content-item[tabid="+E+"]",D.tab.content).remove();A("li[tabid="+E+"]",D.tab.links.ul).remove();D.setTabButton()},addHeight:function(E){var F=D.tab.height()+E;D.setHeight(F)},setHeight:function(E){D.tab.height(E);D.setContentHeight()},setContentHeight:function(){var E=D.tab.height()-D.tab.links.height();D.tab.content.height(E);A("> .l-tab-content-item",D.tab.content).height(E)},getNewTabid:function(){var E=new Date();return E.getTime()},onResize:function(){if(!B.height||typeof(B.height)!="string"||B.height.indexOf("%")==-1){return false}if(D.tab.parent()[0].tagName.toLowerCase()=="body"){var E=A(window).height();E-=parseInt(D.tab.parent().css("paddingTop"));E-=parseInt(D.tab.parent().css("paddingBottom"));D.height=B.heightDiff+E*parseFloat(D.height)*0.01}else{D.height=B.heightDiff+(D.tab.parent().height()*parseFloat(B.height)*0.01)}D.tab.height(D.height);D.setContentHeight()}};if(B.height){D.makeFullHeight=true}D.tab=A(this);if(!D.tab.hasClass("l-tab")){D.tab.addClass("l-tab")}D.tab.content=A('<div class="l-tab-content"></div>');A("> div",D.tab).appendTo(D.tab.content);D.tab.content.appendTo(D.tab);D.tab.links=A('<div class="l-tab-links"><ul style="left: 0px; "></ul></div>');D.tab.links.prependTo(D.tab);D.tab.links.ul=A("ul",D.tab.links);var C=A("> div[lselected=true]",D.tab.content).length>0;D.selectedTabId=A("> div[lselected=true]",D.tab.content).attr("tabid");A("> div",D.tab.content).each(function(I,H){var E=A('<li class=""><a></a><div class="l-tab-links-item-left"></div><div class="l-tab-links-item-right"></div></li>');if(A(H).attr("title")){A("> a",E).html(A(H).attr("title"))}var G=A(H).attr("tabid");if(G==undefined){G=D.getNewTabid();A(H).attr("tabid",G);if(A(H).attr("lselected")){D.selectedTabId=G}}E.attr("tabid",G);if(!C&&I==0){D.selectedTabId=G}var F=A(H).attr("showClose");if(F){E.append("<div class='l-tab-links-item-close'></div>")}A("> ul",D.tab.links).append(E);if(!A(H).hasClass("l-tab-content-item")){A(H).addClass("l-tab-content-item")}});D.selectTabItem(D.selectedTabId);if(B.height){if(typeof(B.height)=="string"&&B.height.indexOf("%")>0){D.onResize();if(B.changeHeightOnResize){A(window).resize(function(){D.onResize()})}}else{D.setHeight(B.height)}}if(D.makeFullHeight){D.setContentHeight()}A("li",D.tab.links).each(function(){D.addTabItemEvent(A(this))});if(this.id==undefined){this.id="LigerUI_"+new Date().getTime()}LigerUIManagers[this.id+"_Tab"]=D;this.usedTab=true})}})(jQuery);