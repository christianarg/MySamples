require.config({
    paths: {
        "jquery": 'vendor/jquery'
    }
});

//requirejs(["jquery","helpers/utils2"], function (jq,utils) {
//    jq('body').text(utils.mostro());
//});

requirejs(["helpers/utils2"], function (utils) {
    console.log(utils.mostro());
});


//requirejs(["pepe/pepe"], function (utils) {
//    console.log(utils.elpepe);
//});