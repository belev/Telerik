define(['../scripts/ui-controller', 'jquery'], function (UI, $) {
   describe('UI controller', function() {
       describe('Create message html', function () {
           it('is valid message html', function () {
              var message = {
                  by: 'pesho',
                  text: 'hello'
              };

               var $div = $('<div />'),
                   $strong = $('<strong />'),
                   $span = $('<span />');

               $div.append($strong)
                   .append($span);

               $strong.html(message.by + ': ');
               $span.html(message.text);

               assert.equal($div.html(), UI.createMessageHtml(message).html());
           });
       });
   });
});