'use strict';

const readline = require('readline');

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

const request = require('request');
var pullLevels = function () {
    request('https://alexakidskill.azurewebsites.net/api/Game/GetLevels', function (error, response, body) {
        var levels = JSON.parse(body);
        //console.log(body);
        getLevel(levels);
    });
}

var pullCategories = function (age) {
    request('https://alexakidskill.azurewebsites.net/api/Game/GetCategories', function (error, response, body) {
        var categories = JSON.parse(body);
        //console.log(body);
        getCategory(categories, age);
    });
}

var getLevel = function (levels) {
    var age = 0;
    rl.question('How old are you?', (input) => {
        age = levels.find(o => o.description.toLowerCase().indexOf(input.toString()) > -1);
        if (age != null) {
            pullCategories(age.levelId);
        }
        else {
            pullCategories("1");
        }
    });
}

var getCategory = function (categories, age) {
    var category = 0;
    rl.question('What category do you want to play?', (input) => {
        category = categories.find(o => o.description.toLowerCase().indexOf(input.toString()) > -1);
        if (category != null) {
            getQuestions(age, category.categoryId);
        }
        else {
            getQuestions(age, "1");
        }
    });
}

var getQuestions = function (age, category) {
    var formData = {
        levelId: age,
        categoryId: category,
        NumberOfQuestions: '5'
    }

    var headers = {
        'content-type': 'application/json',
        'accept': 'application/json'
    }

    var options = {
        url: 'http://alexakidskill.azurewebsites.net/api/Game/GetQuestions',
        method: 'POST',
        headers: headers,
        json: formData
    }

    request(options, function (error, response, body) {
        if (!error && response.statusCode == 200) {
            var questions = body;
            PlayGame(questions, 0, 0);
        } else {
            console.log('error:', error);
        }
    })
}

function PlayGame(questions, questionIndex, score) {
    var question = questions[questionIndex];
    rl.question(question.text + '? ', (input) => {
        var answeredCorrectly = input.indexOf(question.answer.toLowerCase()) > -1;
        GetEncouragement(answeredCorrectly, questions, questionIndex, score);
    });
}

function GetEncouragement(answeredCorrectly, questions,questionIndex, score) {
    var encouragementRequest = require('request');
    encouragementRequest('http://alexakidskill.azurewebsites.net/api/Game/GetEncouragement?answeredCorrectly=' + answeredCorrectly,
        function (error, response, body) {
            var encouragement = JSON.parse(body);
            if (answeredCorrectly == true)
            {
                score += 1;
                console.log('That is correct!', encouragement.text);
            } else {
                console.log(encouragement.text, 'The answer is', questions[questionIndex].answer);
            }

            console.log('Your score is', score, 'out of', questionIndex+1)
            if (questionIndex < questions.length - 1) {
                PlayGame(questions, ++questionIndex, score);
            }
            else {
                console.log('Game ended. Your final score is', score, 'out of', questionIndex + 1)
            }
        })
}

var beginProgram = function () {
    pullLevels();
}


beginProgram();