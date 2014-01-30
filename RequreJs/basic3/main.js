require.config({
    paths: {
        "jquery": 'vendor/jquery'
    }
});

requirejs(["helpers/OldFashionJsWithNamespace"], function (helloWorld) {
    Pb.Eip.HelloWorld.hola();
    helloWorld.hola();
});