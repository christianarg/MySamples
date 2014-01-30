define(function () {
    
    function utils() {
    }
    
    utils.prototype = {
        booleanVar: false,
        showMessage: function () {
            if (this.booleanVar)
                alert('Es true');
            else
                alert('Es false');
        }
    };

    return utils;
});