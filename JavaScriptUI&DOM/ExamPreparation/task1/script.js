function createCalendar(selector, events) {
    var DAYS_OF_WEEK = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
    var i;

    var calendarContainer = document.querySelector(selector);
    var table = document.createElement('table');

    for (i = 0; i < 4; i++) {
        table.appendChild(createTableRow(7, 7 * i));
    }
    table.appendChild(createTableRow(2, 28));

    table = addEventsToTable(table, events);

    table.style.border = '1px solid black';
    table.style.borderCollapse = 'collapse';

    var cellTitles = table.querySelectorAll('.cell-title');

    for (i = 0; i < cellTitles.length; i += 1) {
        cellTitles[i].addEventListener('mouseover', onMouseOver);
        cellTitles[i].addEventListener('mouseout', onMouseOut);
        cellTitles[i].addEventListener('click', onClick);
    }

    calendarContainer.appendChild(table);

    function createTableRow(cellsInRowCount, totalNumberOfCellsAtTheMoment) {
        var row = document.createElement('tr'),
            cellTitle = document.createElement('div'),
            cellContent = document.createElement('div'),
            id,
            i;

        row.className = 'table-row';
        cellTitle.className = 'cell-title';
        cellContent.className = 'cell-content';

        for (i = 0; i < cellsInRowCount; i += 1) {
            var rowCell = document.createElement('td');
            rowCell.className = 'table-cell';
            rowCell.style.verticalAlign = 'top';
            rowCell.style.height = 100 + 'px';
            rowCell.style.border = '1px solid black';

            id = i + totalNumberOfCellsAtTheMoment + 1;

            cellTitle.style.borderBottom = '1px solid black';
            cellTitle.style.backgroundColor = '#CCCCCC';
            cellTitle.style.fontWeight = 'bold';
            cellTitle.style.textAlign = 'center';
            cellTitle.style.padding = '0 10px';
            cellTitle.innerHTML = DAYS_OF_WEEK[i] + ' ' + id + ' ' + 'June 2014';

            rowCell.setAttribute('id', 'd' + id);
            rowCell.appendChild(cellTitle.cloneNode(true));
            rowCell.appendChild(cellContent.cloneNode(true));

            row.appendChild(rowCell);
        }

        return row;
    }

    function addEventsToTable(table, events) {
        var searchedElementId;

        for (var i = 0, len = events.length; i < len; i += 1) {
            searchedElementId = 'd' + events[i].date;

            var searchedElement = table.querySelector('#' + searchedElementId);

            searchedElement.querySelector('.cell-content').innerHTML = events[i].hour + ' ' + events[i].title;
        }

        return table;
    }

    function onMouseOut() {
        if (this.className.indexOf('selected') != -1) {
            return;
        }

        this.style.backgroundColor = '#CCCCCC';
    }

    function onMouseOver() {
        if (this.className.indexOf('selected') != -1) {
            return;
        }
        this.style.backgroundColor = '#565656';
    }

    function onClick() {
        var previouslySelectedElements = table.querySelectorAll('.selected');
        if (previouslySelectedElements) {
            for (var i = 0; i < previouslySelectedElements.length; i += 1) {
                previouslySelectedElements[i].className = previouslySelectedElements[i].className.replace(/\bselected\b/g, '');
                console.log(previouslySelectedElements[i].className);
                previouslySelectedElements[i].style.backgroundColor = '#CCCCCC';
            }
        }

        this.className += ' selected';
        this.style.backgroundColor = '#1a1a1a';
    }
}