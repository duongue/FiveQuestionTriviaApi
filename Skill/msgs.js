module.exports = function () {
    var request = require('request');
    request('https://alexakidskill.azurewebsites.net/api/Game/GetLevels', function (error, response, body) {
        this.first = body;
    })
};