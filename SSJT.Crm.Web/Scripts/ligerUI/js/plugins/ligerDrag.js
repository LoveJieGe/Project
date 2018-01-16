/**
* jQuery ligerUI 1.0.0
* 
* Author leoxie [ gd_star@163.com ] 
* 
*/

(function ($)
{
    ///	<param name="$" type="jQuery"></param>  
    $.fn.ligerDrag = function (p)
    {
        p = $.extend({ onStartDrag: false, onDrag: false, onStopDrag: false }, p || {});
        return this.each(function ()
        {
            if (this.useDrag) return;
            var g = {
                start: function (e)
                {
                    $('body').css('cursor', 'move');
                    g.current = {
                        target: g.target,
                        left: g.target.offset().left,
                        top: g.target.offset().top,
                        startX: e.pageX || e.screenX,
                        startY: e.pageY || e.clientY
                    };
                    $(document).bind('mouseup', g.stop);
                    $(document).bind('mousemove', g.drag);
                    if (p.onStartDrag) p.onStartDrag(g.current, e);
                },
                drag: function (e)
                {
                    var startX = e.pageX || e.screenX;
                    var startY = e.pageY || e.screenY;
                    g.current.diffX = startX - g.current.startX;
                    g.current.diffY = startY - g.current.startY;
                    if (p.onDrag)
                    {
                        if (p.onDrag(g.current, e) != false)
                        {
                            g.applyDrag();
                        }
                    }
                    else
                    {
                        g.applyDrag();
                    }
                },
                stop: function (e)
                {
                    $(document).unbind('mousemove', g.drag);
                    $(document).unbind('mouseup', g.stop);
                    $("body").css("cursor", "");
                    if (p.onStopDrag) p.onStopDrag(g.current, e);
                    g.current = null;
                },
                //更新当前坐标
                applyDrag: function ()
                {
                    if (g.current.diffX)
                    {
                        g.target.css("left", (g.current.left + g.current.diffX));
                    }
                    if (g.current.diffY)
                    {
                        g.target.css("top", (g.current.top + g.current.diffY));
                    }
                }
            };
            g.target = $(this);
            if (p.handler == undefined || p.handler == null)
                g.handler = $(this);
            else
                g.handler = (typeof p.handler == 'string' ? $(p.handler, this) : p.handle);
            g.handler.hover(function ()
            {
                $('body').css('cursor', 'move');
            }, function ()
            {
                $("body").css("cursor", "");
            }).mousedown(function (e)
            {
                g.start(e);
                return false;
            });
            this.useDrag = true;
        });
    };
})(jQuery);