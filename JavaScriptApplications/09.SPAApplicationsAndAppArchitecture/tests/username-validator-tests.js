define(['../scripts/username-validator'], function (UsernameValidator) {
    describe('UsernameValidator', function () {
        describe('Test isValidUsername', function () {
            it('valid name test', function () {

                expect(UsernameValidator.isValidUsername('Peshoo')).to.equal(true);
            });

            it('invalid name test min length', function () {

                expect(UsernameValidator.isValidUsername('an')).to.equal(false);
            });

            it('invalid name test max length', function () {
                expect(UsernameValidator.isValidUsername('xaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxaxa')).to.equal(false);
            });
        });
    });
});

