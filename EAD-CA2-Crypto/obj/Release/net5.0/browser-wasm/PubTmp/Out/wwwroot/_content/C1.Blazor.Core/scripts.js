function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

class Semaphore {
    constructor() {
        this.promises = []
    }

    waitAsync() {
        //console.log('Semaphore.waitAsync()');
        var promiseHolder = new Object();
        var promise = new Promise(function (resolve, reject) {
            promiseHolder.resolve = resolve;
            promiseHolder.reject = reject;
        });
        promiseHolder.promise = promise;
        this.promises.push(promiseHolder);
        if (this.promises.length == 1) {
            promiseHolder.resolve();
        }
        return promiseHolder.promise;
    }

    release() {
        //console.log('Semaphore.release()');
        this.promises.splice(0, 1);
        if (this.promises.length > 0) {
            var promiseHolder = this.promises[0];
            promiseHolder.resolve();
        }
    }
}


window.C1Common =
{
    browser: {

        isFirefox: () => {
            var isFirefox = typeof InstallTrigger !== 'undefined';
            return isFirefox;
        },

        isSafari: () => {
            var isSafari = /constructor/i.test(window.HTMLElement) || (function (p) { return p.toString() === "[object SafariRemoteNotification]"; })(!window['safari'] || (typeof safari !== 'undefined' && window['safari'].pushNotification));

            return isSafari;
        }
    }
}


/************ C1View ************/
window.C1View = {
    getWidth: function (element) {
        return element.offsetWidth;
    },
    getHeight: function (element) {
        return element.offsetHeight;
    },
    getSize: function (element) {
        return [element.offsetWidth, element.offsetHeight];
    },
    focus: function (element, selectAll, preventScroll) {
        if (element && document.activeElement != element) {
            element.focus({ preventScroll: preventScroll });
            if (selectAll && element.select)
                element.select();
            return true;
        }
        return false;
    },
};

/************ C1ToggleButton ************/
window.C1ToggleButton = {
    init: function (input, componentReference) {
        input.ComponentReference = componentReference;
    },
    onClick: function (element) {
        element.ComponentReference.invokeMethodAsync('OnClick');
    },
};

/************ C1Icon ************/
window.C1Icon = {
    getBoundingBox: function (svg) {
        var box = svg.getBBox();
        return [box.x, box.y, box.width, box.height];
    },
    getPathBoundingBox: function (path) {
        var svg = document.createElementNS("http://www.w3.org/2000/svg", "svg");
        var newElement = document.createElementNS("http://www.w3.org/2000/svg", 'path');
        newElement.setAttribute("d", path);
        svg.appendChild(newElement);
        window.document.body.appendChild(svg);
        var boundingBox = window.C1Icon.getBoundingBox(svg);
        window.document.body.removeChild(svg);
        return boundingBox;
    },
};

/************ C1ScrollViewer ************/
window.C1ScrollViewer = {
    init: function (scrollable, content, topHeader, leftHeader, topLeftHeader, hiddenTextBox, onScroll, componentReference) {
        scrollable.Content = content;
        scrollable.TopHeader = topHeader;
        scrollable.LeftHeader = leftHeader;
        scrollable.TopLeftHeader = topLeftHeader;
        scrollable.HiddenTextBox = hiddenTextBox;
        scrollable.ComponentReference = componentReference;
        scrollable.onmouseover = window.C1ScrollViewer.onHover;
        scrollable.onmouseleave = window.C1ScrollViewer.onHover;
        //scrollable.onmousedown = e => e.preventDefault();
        scrollable.Semaphore = new Semaphore();
        scrollable.LastOffset = [0, 0];
        scrollable.LastSize = [0, 0];
        scrollable.OnScrollFunc = eval(onScroll);
        scrollable.onscroll = e => {
            if (scrollable.OnScrollFunc != null)
                var cancel = scrollable.OnScrollFunc(e);
            if (!cancel)
                window.C1ScrollViewer.onScroll(e);
        }
        hiddenTextBox.Scrollable = scrollable;
        scrollable.onkeydown = window.C1ScrollViewer.onKeyDown;
        scrollable.onkeyup = window.C1ScrollViewer.onKeyUp;

        hiddenTextBox.oninput = window.C1ScrollViewer.oninput;
        scrollable.ontouchstart = e => {
            scrollable.style.overflow = "scroll";
        }

        var _onresize = function (e) {
            var currentSize = [scrollable.offsetWidth, scrollable.offsetHeight];

            if (scrollable.LastSize[0] != currentSize[0] || scrollable.LastSize[1] != currentSize[1]) {
                scrollable.LastSize = currentSize;
                componentReference.invokeMethodAsync('OnScrollViewerScroll', scrollable.LastOffset[0], scrollable.LastOffset[1], currentSize[0], currentSize[1]);
            }
        }

        if (typeof ResizeObserver !== "undefined") {
            new ResizeObserver(_onresize).observe(scrollable);
        } else if (window.addResizeObserver) {
            addResizeObserver(scrollable, _onresize);
        }

    },
    setScrollTop: function (element, scrollTop) {
        element.scrollTop = scrollTop;
    },
    getScrollTop: function (element) {
        return element.scrollTop;
    },
    setScrollLeft: function (element, scrollLeft) {
        element.scrollLeft = scrollLeft;
    },
    getScrollLeft: function (element) {
        return element.scrollLeft;
    },
    setScroll: function (element, scrollLeft, scrollTop) {
        if (scrollLeft !== "undefined" && scrollLeft !== null)
            element.scrollLeft = scrollLeft;
        if (scrollTop !== "undefined" && scrollTop !== null)
            element.scrollTop = scrollTop;
    },
    getScroll: function (element) {
        return [element.scrollLeft, element.scrollTop];
    },
    getViewport: function (element) {
        return [element.scrollLeft, element.scrollTop, element.offsetWidth, element.offsetHeight];
    },
    onScroll: async function (e) {
        var scrollable = e.currentTarget;
        //console.log('onScroll ' + Date.now())

        //var content = scrollable.Content;
        //var topHeader = scrollable.TopHeader;
        //var leftHeader = scrollable.LeftHeader;
        //var topLeftHeader = scrollable.TopLeftHeader;

        var componentReference = scrollable.ComponentReference;
        var semaphore = scrollable.Semaphore;
        try {
            var initialOffset = [scrollable.scrollLeft, scrollable.scrollTop];
            await sleep(20);
            await semaphore.waitAsync();
            var currentOffset = [scrollable.scrollLeft, scrollable.scrollTop];
            if (initialOffset[0] != currentOffset[0] || initialOffset[1] != currentOffset[1])
                return;
            var lastOffset = scrollable.LastOffset;
            if (lastOffset[0] != currentOffset[0] || lastOffset[1] != currentOffset[1]) {
                //var before = Date.now();
                scrollable.LastOffset = currentOffset;

                await componentReference.invokeMethodAsync('OnScrollViewerScroll', currentOffset[0], currentOffset[1], scrollable.offsetWidth, scrollable.offsetHeight);
                //var after = Date.now();
                //console.log((after - before).toString())
            }
        }
        finally {
            semaphore.release();
        }
    },
    onHover: function (e) {
        //console.log('onHover')
        //var scrollable = e.currentTarget;
        //var content = scrollable.Content;
        //var topHeader = scrollable.TopHeader;
        //var leftHeader = scrollable.LeftHeader;
        //var topLeftHeader = scrollable.TopLeftHeader;
    },
    onKeyDown: function (e) {
        var scrollable = e.currentTarget;
        if (e.target != scrollable.HiddenTextBox && e.key != 'Enter' && e.key != 'Escape' && e.key != 'Tab') {
            return true;
        }

        window.C1ScrollViewer.onKeyDownAsync(e);
        if (e.key == 'Tab' || e.key == 'PageUp' || e.key == 'PageDown') //Avoid Tab key to move focus to browser address bar.
            e.preventDefault();
        //return true;
    },
    onKeyDownAsync: async function (e) {
        var scrollable = e.currentTarget;
        var componentReference = scrollable.ComponentReference;
        var semaphore = scrollable.Semaphore;
        try {
            var before = Date.now();
            await semaphore.waitAsync();
            var after = Date.now();
            if (after - before < 100) {
                await componentReference.invokeMethodAsync('OnScrollViewerKeyDownAsync', e.key, e.code, e.location, e.repeat, e.ctrlKey, e.shiftKey, e.altKey, e.metaKey);
            }
        }
        finally {
            semaphore.release();
        }
    },

    onKeyUp: function (e) {
        var scrollable = e.currentTarget;
        if (e.target != scrollable.HiddenTextBox && e.key != 'Enter' && e.key != 'Escape' && e.key != 'Tab') {
            return true;
        }

        window.C1ScrollViewer.onKeyUpAsync(e);
        if (e.key == 'Tab' || e.key == 'PageUp' || e.key == 'PageDown') //Avoid Tab key to move focus to browser address bar.
            e.preventDefault();
        //return true;
    },

    onKeyUpAsync: async function (e) {
        var scrollable = e.currentTarget;
        var componentReference = scrollable.ComponentReference;
        await componentReference.invokeMethodAsync('OnScrollViewerKeyUpAsync', e.key, e.code, e.location, e.repeat, e.ctrlKey, e.shiftKey, e.altKey, e.metaKey);
    },
    oninput: function (e) {
        var hiddenTextBox = e.currentTarget;
        window.C1ScrollViewer.onInputAsync(e);
    },
    onInputAsync: async function (e) {
        var hiddenTextBox = e.currentTarget;
        var scrollable = hiddenTextBox.Scrollable;
        var componentReference = scrollable.ComponentReference;
        if (hiddenTextBox.value)
            await componentReference.invokeMethodAsync('OnScrollViewerInputAsync', e.data);
    },
};

