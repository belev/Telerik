(function ($) {
    $.fn.dropdown = function () {
        var $this = $(this).hide();

        var selectionOptions = $this.find('option');

        var $dropdownListContainer = $('<div />');
        $dropdownListContainer.addClass('dropdown-list-container');

        var $dropdownListOptions = $('<ul />');
        $dropdownListOptions.addClass('dropdown-list-options');

        var $dropdownOption = $('<li />');
        $dropdownOption.addClass('dropdown-list-option');

        for (var i = 0, len = selectionOptions.length; i < len; i += 1) {
            var optionHtml = $(selectionOptions[i]).html();

            $dropdownOption.data('data-value', i);
            $dropdownOption.html(optionHtml);

            $dropdownListOptions.append($dropdownOption.clone(true));
        }

        $dropdownListContainer.append($dropdownListOptions);
        $this.after($dropdownListContainer);

        var $allLiItems = $dropdownListContainer.find('.dropdown-list-option');

        $allLiItems.on('click', function () {
            var $this = $(this);

            var $dropdown = $('#dropdown');
            var $dropdownListOptions = $('.dropdown-list-options');

            $dropdown.find(':selected').removeAttr('selected', '');
            $dropdownListOptions.find('.selected-item')
                .removeClass('selected-item')
                .css('color', 'black');

            var clickedItemDataValue = $this.data('data-value') + 1;

            $dropdown.find("option[value='" + clickedItemDataValue + "']")
                .attr('selected', 'selected');

            $this.addClass('selected-item');
            $dropdownListOptions.find('.selected-item').css('color', 'green');
        });
    };
}($));