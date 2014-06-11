function init() {
    function addElement() {
        var elementValue = document.getElementById('input-field');

        if (elementValue != null) {
            var li = document.createElement('li');
            var html = '';
            html += '<div class="content"><input type="checkbox" id="button-selected"><span>' + elementValue.value + '</span></div>';
            li.innerHTML = html;
            elementsList.appendChild(li);
        }
    }

    function deleteElements() {
        var selectedList = elementsList.querySelectorAll('#button-selected');
        for (var i = 0; i < selectedList.length; i++) {
            if (selectedList[i].checked) {
                // remove from the ul the selected li element
                selectedList[i].parentElement.parentElement.parentElement.removeChild(selectedList[i].parentElement.parentElement);
            }
        }
    }

    function hideElements() {
        var selectedList = elementsList.querySelectorAll('#button-selected');
        for (var i = 0; i < selectedList.length; i++) {
            if (selectedList[i].checked) {
                // hide the selected li elements
                selectedList[i].parentElement.parentElement.style.display = 'none';
                selectedList[i].checked = false;
            }
        }
    }

    function showElements() {
        var selectedList = elementsList.querySelectorAll('li');
        for (var i = 0; i < selectedList.length; i++) {
            if (selectedList[i].style.display === 'none') {
                selectedList[i].style.display = 'block';
            }
        }
    }

    var elementsList = document.getElementById('added-elements-list');
    elementsList.style.listStyleType = 'none';

    var addButton = document.getElementById('add-button');
    addButton.addEventListener('click', addElement, false);

    var deleteButton = document.getElementById('delete-button');
    deleteButton.addEventListener('click', deleteElements, false);

    var hideButton = document.getElementById('hide-button');
    hideButton.addEventListener('click', hideElements, false);

    var showButton = document.getElementById('show-button');
    showButton.addEventListener('click', showElements, false);
}