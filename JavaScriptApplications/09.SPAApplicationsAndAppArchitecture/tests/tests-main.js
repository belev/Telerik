(function () {

    require.config({
        paths: {
            mocha: '../node_modules/mocha/mocha',
            chai: '../node_modules/chai/chai',
            jquery: '../libs/jquery'
        }
    });

    require(['chai', 'mocha'], function (chai) {
        mocha.setup('bdd');
        expect = chai.expect;
        assert = chai.assert;
        var should = chai.should();
        require(['./username-validator-tests', './ui-controller-tests'], function () {
            mocha.run();
        })
    });
}());