$.fn.tabs = function () {
    var $self = $(this);
    $self.addClass('tabs-container');

    $self.find('.tab-item-content').hide();

    $self.find('.tab-item-title')
        .on('click', function () {
            $self.find('.tab-item-content').hide();
            $self.find('.tab-item.current').removeClass('current');

            var $this = $(this);
            var parent = $this.parent().addClass('current');


            parent.find('.tab-item-content').show();
        });
};