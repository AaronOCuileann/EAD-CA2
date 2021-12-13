/************ FlexGrid ************/
window.GridBase = {
    init: function (scrollable, adornerLayer, componentReference) {
        scrollable.GridComponentReference = componentReference;
        scrollable.AdornerLayer = adornerLayer;
        scrollable.onmousemove = onmousemove;
        scrollable.onmouseleave = onmouseleave;
        scrollable.onpointerdown = dragStart;
        scrollable.onpointermove = drag;
        scrollable.onpointercancel = dragEnd;
        scrollable.onpointerup = dragEnd;
        scrollable.onlostpointercapture = dragEnd;
        scrollable.addEventListener("touchstart", function (e) {
            if (columnIndex >= 0 || rowIndex >= 0) {
                e.preventDefault();
            }
        });
        scrollable.addEventListener("click", function (e) {
            if (columnIndex >= 0 || rowIndex >= 0) {
                e.preventDefault();
                e.stopPropagation();
                e.stopImmediatePropagation();
            }
        });
        var active = false;
        var initialX;
        var initialY;
        var columnIndex = -1;
        var rowIndex = -1;
        var columnWidth;
        var rowHeight;

        function onmousemove(e) {
            if (!active) {
                var scrollable = e.currentTarget;
                var scrollableBoundingRect = scrollable.getBoundingClientRect();
                var x = e.clientX - scrollableBoundingRect.x;
                var y = e.clientY - scrollableBoundingRect.y;
                var p = window.GridBase.convertFromAdornerLayerPoint(scrollable, [x, y]);
                closestHeaders = window.GridBase.getClosestHeaderEdges(scrollable, p[0], p[1], 5);
                columnIndex = closestHeaders[0];
                rowIndex = closestHeaders[1];
                //console.log("onmousemove columnIndex=" + columnIndex + " rowIndex=" + rowIndex)
                if (columnIndex >= 0)
                    scrollable.style.cursor = "col-resize";
                else if (rowIndex >= 0)
                    scrollable.style.cursor = "row-resize";
                else
                    scrollable.style.cursor = "default";
            }
        }

        function onmouseleave(e) {
            var scrollable = e.currentTarget;
            scrollable.style.cursor = "default";
        }

        function dragStart(e) {
            initialX = e.clientX;
            initialY = e.clientY;

            if (e.pointerType == "touch" || e.pointerType == "pen") {
                var scrollableBoundingRect = scrollable.getBoundingClientRect();
                var x = e.clientX - scrollableBoundingRect.x;
                var y = e.clientY - scrollableBoundingRect.y;
                var p = window.GridBase.convertFromAdornerLayerPoint(scrollable, [x, y]);
                closestHeaders = window.GridBase.getClosestHeaderEdges(scrollable, p[0], p[1], 12);
                columnIndex = closestHeaders[0];
                rowIndex = closestHeaders[1];
                if (columnIndex >= 0 || rowIndex >= 0) {
                    scrollable.style.touchAction = "none";
                    e.preventDefault();
                    e.stopPropagation();
                    e.stopImmediatePropagation();
                }
            }

            if (columnIndex >= 0 || rowIndex >= 0) {
                e.preventDefault();
                e.stopPropagation();
                e.stopImmediatePropagation();

                scrollable.setPointerCapture(e.pointerId);
                active = true;
                if (columnIndex >= 0) {
                    columnWidth = window.GridBase.getColumnInfo(scrollable, columnIndex)[1];
                    if (e.pointerType == "touch" || e.pointerType == "pen")
                        drawColumnResizingLine(columnIndex, columnWidth);
                    //console.log("dragStart column" + columnIndex + " " + columnWidth)
                }
                else {
                    rowHeight = window.GridBase.getRowInfo(scrollable, rowIndex)[1];
                    if (e.pointerType == "touch" || e.pointerType == "pen")
                        drawRowResizingLine(rowIndex, rowHeight);
                    //console.log("dragStart row" + rowIndex + " " + rowHeight)
                }
            }
        }

        function drag(e) {
            if (active) {

                e.preventDefault();
                e.stopPropagation();
                e.stopImmediatePropagation();

                var currentX = e.clientX - initialX;
                var currentY = e.clientY - initialY;

                if (columnIndex >= 0) {
                    var newWidth = Math.max(0, columnWidth + currentX);
                    if (e.pointerType == "touch" || e.pointerType == "pen") {
                        drawColumnResizingLine(columnIndex, newWidth);
                    }
                    //console.log("ResizeColumn columnIndex=" + columnIndex + " columnWidth=" + columnWidth + " currentX=" + currentX)
                    componentReference.invokeMethodAsync('ResizeColumn', columnIndex, newWidth);
                }
                else if (rowIndex >= 0) {
                    var newHeight = rowHeight + currentY;
                    //console.log("ResizeRow rowIndex=" + rowIndex + " rowHeight=" + rowHeight + " currentX=" + currentY)
                    if (e.pointerType == "touch" || e.pointerType == "pen") {
                        drawRowResizingLine(rowIndex, newHeight);
                    }
                    componentReference.invokeMethodAsync('ResizeRow', rowIndex, newHeight);
                }
            }
        }

        function dragEnd(e) {
            if (active) {
                active = false;
                e.preventDefault();
                e.stopPropagation();
                e.stopImmediatePropagation();
                initialX = 0;
                initialY = 0;
                adornerLayer.innerHTML = '';
                scrollable.style.touchAction = "auto";
                scrollable.releasePointerCapture(e.pointerId);
            }
        }

        function drawColumnResizingLine(col, newWidth) {
            var scrollableBoundingRect = scrollable.getBoundingClientRect();
            var colInfo = window.GridBase.getColumnInfo(scrollable, col);
            var x = window.GridBase.convertToAdornerLayerPoint(scrollable, [colInfo[0] + newWidth, 0])[0]
            var line = createline(x, 0, x, scrollableBoundingRect.height, 'rgb(0,0,0)', 2);
            adornerLayer.innerHTML = '';
            adornerLayer.appendChild(line);
        }

        function drawRowResizingLine(rowIndex, newheight) {
            var scrollableBoundingRect = scrollable.getBoundingClientRect();
            var rowInfo = window.GridBase.getRowInfo(scrollable, rowIndex);
            var y = window.GridBase.convertToAdornerLayerPoint(scrollable, [0, rowInfo[0] + newheight])[1]
            var line = createline(0, y, scrollableBoundingRect.width, y, 'rgb(0,0,0)', 2);
            adornerLayer.innerHTML = '';
            adornerLayer.appendChild(line);
        }

        function createline(x1, y1, x2, y2, color, w) {
            var aLine = document.createElementNS('http://www.w3.org/2000/svg', 'line');
            aLine.setAttribute('x1', x1);
            aLine.setAttribute('y1', y1);
            aLine.setAttribute('x2', x2);
            aLine.setAttribute('y2', y2);
            aLine.setAttribute('stroke', color);
            aLine.setAttribute('stroke-width', w);
            return aLine;
        }
    },
    convertFromAdornerLayerPoint: function (scrollable, point) {
        var topLeftPanel = scrollable.childNodes[1].childNodes[3].childNodes[3];
        var x = (point[0] > topLeftPanel.clientWidth ? (point[0] + scrollable.scrollLeft) : point[0]);
        var y = (point[1] > topLeftPanel.clientHeight ? (point[1] + scrollable.scrollTop) : point[1]);
        return [x, y];
    },
    convertToAdornerLayerPoint: function (scrollable, point) {
        var topLeftPanel = scrollable.childNodes[1].childNodes[3].childNodes[3];
        var x = (point[0] > topLeftPanel.clientWidth ? (point[0] - scrollable.scrollLeft) : point[0]);
        var y = (point[1] > topLeftPanel.clientHeight ? (point[1] - scrollable.scrollTop) : point[1]);
        return [x, y];
    },
    getClosestHeaderEdges: function (scrollable, x, y, threshold) {
        var col = -1;
        var row = -1;
        if (y > 0 && y < window.GridBase.getColumnHeadersHeight(scrollable)) {
            col = window.GridBase.getClosestColumnEdge(scrollable, x, threshold);
        }
        else if (x > 0 && x < window.GridBase.getRowHeadersWidth(scrollable)) {
            row = window.GridBase.getClosestRowEdge(scrollable, y, threshold);
        }
        return [col, row];
    },
    getColumnHeadersHeight: function (scrollable) {
        var topLeftPanel = scrollable.childNodes[1].childNodes[3].childNodes[3];
        return topLeftPanel.clientHeight;
    },
    getRowHeadersWidth: function (scrollable) {
        var topLeftPanel = scrollable.childNodes[1].childNodes[3].childNodes[3];
        return topLeftPanel.clientWidth;
    },
    getClosestColumnEdge: function (scrollable, x, threshold) {
        var columnIndex = -1;
        var col = 0;
        var count = window.GridBase.getColumnsCount(scrollable);
        while (col < count) {
            if (window.GridBase.allowResizingColumn(scrollable, col)) {
                var colInfo = window.GridBase.getColumnInfo(scrollable, col);
                var offset = colInfo[0] + colInfo[1];
                var distance = offset - x;
                if (Math.abs(distance) < threshold)
                    columnIndex = col;
                else if (distance > threshold)
                    break;
            }
            col++;
        }
        return columnIndex;
    },
    getClosestRowEdge: function (scrollable, y, threshold) {
        var rowIndex = -1;
        var row = 0;
        var count = window.GridBase.getRowsCount(scrollable);
        while (row < count) {
            if (window.GridBase.allowResizingRow(scrollable, row)) {
                var rowInfo = window.GridBase.getRowInfo(scrollable, row);
                var offset = rowInfo[0] + rowInfo[1];
                var distance = offset - y;
                if (Math.abs(distance) < threshold)
                    rowIndex = row;
                else if (distance > threshold)
                    break;
            }
            row++;
        }
        return rowIndex;
    },
    getColumnsCount: function (scrollable) {
        var topPanelColumns = scrollable.childNodes[1].childNodes[1].childNodes[1]
        var topLeftPanelColumns = scrollable.childNodes[1].childNodes[3].childNodes[1]
        return parseInt(topLeftPanelColumns.getAttribute("count")) + parseInt(topPanelColumns.getAttribute("count"));
    },
    getRowsCount: function (scrollable) {
        var leftPanelRows = scrollable.childNodes[1].childNodes[2].childNodes[2]
        var topLeftPanelRows = scrollable.childNodes[1].childNodes[3].childNodes[2]
        return parseInt(topLeftPanelRows.getAttribute("count")) + parseInt(leftPanelRows.getAttribute("count"));
    },
    getColumn: function (scrollable, columnIndex) {
        var topLeftPanelColumns = scrollable.childNodes[1].childNodes[3].childNodes[1];
        var frozenColumns = parseInt(topLeftPanelColumns.getAttribute("count"));
        if (columnIndex < frozenColumns) {
            for (var i = 0; i < topLeftPanelColumns.childNodes.length; i++) {
                var column = topLeftPanelColumns.childNodes[i];
                if (column !== undefined && parseInt(column.getAttribute("index")) == columnIndex) {
                    return column;
                }
            }
        }
        var topPanelColumns = scrollable.childNodes[1].childNodes[1].childNodes[1]
        for (var i = 0; i < topPanelColumns.childNodes.length; i++) {
            var column = topPanelColumns.childNodes[i];
            if (column !== undefined && parseInt(column.getAttribute("index")) == columnIndex) {
                return column;
            }
        }
        return undefined;
    },
    getRow: function (scrollable, rowIndex) {
        var topLeftPanelRows = scrollable.childNodes[1].childNodes[3].childNodes[2];
        var frozenRows = parseInt(topLeftPanelRows.getAttribute("count"));
        if (rowIndex < frozenRows) {
            for (var i = 0; i < topLeftPanelRows.childNodes.length; i++) {
                var row = topLeftPanelRows.childNodes[i];
                if (row !== undefined && parseInt(row.getAttribute("index")) == rowIndex) {
                    return row;
                }
            }
        }
        var leftPanelRows = scrollable.childNodes[1].childNodes[2].childNodes[2]
        for (var i = 0; i < leftPanelRows.childNodes.length; i++) {
            var row = leftPanelRows.childNodes[i];
            if (row !== undefined && parseInt(row.getAttribute("index")) == rowIndex) {
                return row;
            }
        }
        return undefined;
    },
    allowResizingColumn: function (scrollable, columnIndex) {
        var column = window.GridBase.getColumn(scrollable, columnIndex);
        if (column === undefined)
            return false;
        var allowResizing = column.getAttribute("allowResizing");
        if (allowResizing != null)
            return allowResizing == "true";
        return column.parentNode.getAttribute("allowResizing") == "true";
    },
    allowResizingRow: function (scrollable, rowIndex) {
        var row = window.GridBase.getRow(scrollable, rowIndex);
        if (row === undefined)
            return false;
        var allowResizing = row.getAttribute("allowResizing");
        if (allowResizing != null)
            return allowResizing == "true";
        return row.parentNode.getAttribute("allowResizing") == "true";
    },
    getColumnInfo: function (scrollable, columnIndex) {
        var topLeftPanelColumns = scrollable.childNodes[1].childNodes[3].childNodes[1];
        var topLeftPanel = scrollable.childNodes[1].childNodes[3].childNodes[3];
        var frozenColumns = parseInt(topLeftPanelColumns.getAttribute("count"));
        if (columnIndex < frozenColumns) {
            var cell = window.GridBase.getFirstCellOfColumn(topLeftPanel, columnIndex);
            if (cell != null)
                return [cell.offsetLeft, cell.clientWidth];
        }
        var topPanel = scrollable.childNodes[1].childNodes[1].childNodes[3];
        var cell = window.GridBase.getFirstCellOfColumn(topPanel, columnIndex - frozenColumns);
        if (cell != null)
            return [topLeftPanel.clientWidth + cell.offsetLeft, cell.clientWidth];
        return [0, 0];
    },
    getRowInfo: function (scrollable, rowIndex) {
        var topLeftPanelRows = scrollable.childNodes[1].childNodes[3].childNodes[2];
        var topLeftPanel = scrollable.childNodes[1].childNodes[3].childNodes[3];
        var frozenRows = parseInt(topLeftPanelRows.getAttribute("count"));
        if (rowIndex < frozenRows) {
            var cell = window.GridBase.getFirstCellOfRow(topLeftPanel, rowIndex);
            if (cell != null)
                return [cell.offsetTop, cell.clientHeight];
        }
        var leftPanel = scrollable.childNodes[1].childNodes[2].childNodes[3];
        var cell = window.GridBase.getFirstCellOfRow(leftPanel, rowIndex - frozenRows);
        if (cell != null)
            return [topLeftPanel.clientHeight + cell.offsetTop, cell.clientHeight];
        return [0, 0];
    },
    getFirstCellOfColumn: function (gridCellsPanel, columnIndex) {
        for (child in gridCellsPanel.childNodes) {
            var cell = gridCellsPanel.childNodes[child];
            if (cell.tagName == 'DIV' && parseInt(cell.style.gridColumnStart) - 1 == columnIndex && cell.style.gridColumnEnd == "auto")
                return cell;
        }
        return null;
    },
    getFirstCellOfRow: function (gridCellsPanel, rowIndex) {
        for (child in gridCellsPanel.childNodes) {
            var cell = gridCellsPanel.childNodes[child];
            if (cell.tagName == 'DIV' && parseInt(cell.style.gridRowStart) - 1 == rowIndex && cell.style.gridRowEnd == "auto")
                return cell;
        }
        return null;
    },
    transferFocus: async function (input1, input2) {
        var currentValue = input2.value;
        window.C1TextBox.setText(input1, currentValue, '');
        window.C1View.focus(input1, false);
        var oldType = input1.type;
        input1.type = "text";//This is necessary to avoid chrome exception
        input1.setSelectionRange(input1.value.length, input1.value.length);
        input1.type = oldType;
        input2.value = '';
        await window.C1TextBox.notifyTextChange(input1, currentValue);
    },
    clearInput: async function (input) {
        input.value = '';
    },
    onScroll: function (e) {
        //var scrollable = e.currentTarget;
        //var content = scrollable.Content;
        //var topHeader = scrollable.TopHeader;
        //var leftHeader = scrollable.LeftHeader;
        //var topLeftHeader = scrollable.TopLeftHeader;

        //var scrollTop = scrollable.scrollTop;
        //var scrollLeft = scrollable.scrollLeft;

        //var firstRow = scrollTop / 47;
        //var lastRow = (scrollTop + scrollable.clientHeight) / 47;
        //var firstColumn = scrollLeft / 100;
        //var lastColumn = (scrollLeft + scrollable.clientWidth) / 100;

        //var gridPanel = content.children[0];

        //for (i = 0; i < gridPanel.children.length; i++) {
        //    var cell = gridPanel.children[i];
        //    var column = cell.style.gridColumn;
        //    var row = cell.style.gridRow;
        //}
    },
};