require.config({
    paths: {
        "jquery": 'vendor/jquery'
    }
});



requirejs(["jquery","helpers/utils2"], function (jq,utils) {
    jq('body').text(utils.mostro);
});

