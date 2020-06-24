var scaling = 1;

function calculateResult() {
    var questions = parseInt(jQuery('#qNumber').val());
    var correct = questions - parseInt(jQuery('#wrongNumber').val());

    var res = (correct / questions) * 100;
    var showDec = $('#showDecimal').is(':checked');
    if (showDec) {
        res = res.toFixed(2);
    } else {
        res = res.toFixed(0);
    }

    var letter = calculateGradeLetter(res);

    $("#percentRes").val(res + "%");
    $("#letterRes").val(letter);
    $("#fractionRes").val(correct + "/" + questions);
    
    jQuery('#result').val(correct + "/" + questions + " = " + res + "%");
    DrawChart(questions, showDec);
    DrawQuickChart(questions, showDec);
}

function calculateGradeLetter(res) {
    var letter;

    if (scaling === 2) {
        if (res >= 95) letter = "A+";
        else if (res >= 93) letter = "A";
        else if (res >= 90) letter = "A-";
        else if (res >= 87) letter = "B+";
        else if (res >= 83) letter = "B";
        else if (res >= 80) letter = "B-";
        else if (res >= 77) letter = "C+";
        else if (res >= 73) letter = "C";
        else if (res >= 70) letter = "C-";
        else if (res >= 67) letter = "D+";
        else if (res >= 63) letter = "D";
        else if (res >= 60) letter = "D-";
        else letter = "F";
    } else {
        if (res >= 90) letter = "A";
        else if (res >= 80) letter = "B";
        else if (res >= 70) letter = "C";
        else if (res >= 60) letter = "D";
        else letter = "F";
    }
    return letter;
}

function DrawChart(questions, showDec) {
    var ct = "<table class='omrChart' style='min-width: 500px;margin: auto;margin-top: -12px;'><tr>";
    ct += "<th>Questions</th><th>Wrong</th><th>Grade (%)</th><th>Grade (letter)</th>";
    for (i = 1; i <= questions; i++) {
        var percRes = ((questions - i) / questions) * 100;

        if (showDec) {
            percRes = percRes.toFixed(2);
        } else {
            percRes = percRes.toFixed(0);
        }

        var letter = calculateGradeLetter(percRes);

        ct += "<tr class='omrChartRow'>" +
            "<td>"+ questions + "</td>" +
            "<td>"+ i + "</td>" +
            "<td>" + percRes + "%</td>" +
            "<td>" + letter + "</td></tr>";
    }

    ct += "</tr></table>";

    jQuery('.chartDiv').html(ct);
}

function DrawQuickChart(questions, showDec) {
    var ct = "<table class='omrChart' style='min-width: 500px;margin: auto;margin-top: -12px;'><tr>";
    ct += "<th>Grade (letter)</th><th>Wrong</th><th>Correct</th><th>Questions</th>";

    var letters, thresholds;
    if (scaling === 2) {
        letters = ["A+", "A", "A-", "B+", "B", "B-", "C+", "C", "C-", "D+", "D", "D-", "F"];
        thresholds = [
            100, 95,
            94.99, 93,
            92.99, 90,
            89.99, 87,
            86.99, 83,
            82.99, 80,
            79.99, 77,
            76.99, 73,
            72.99, 70,
            69.99, 67,
            66.99, 63,
            62.99, 60,
            59.99, 0
        ];

    } else {
        letters = ["A", "B", "C", "D", "F"];
        thresholds = [100, 90, 89.99, 80, 79.99, 70, 69.99, 60, 59.99, 0];
    }

    for (i = 0; i < letters.length; i++) {

        var upperCorrect = Math.floor(questions * thresholds[2*i] / 100);
        var upperWrong = questions - upperCorrect;
        var lowerCorrect = Math.ceil(questions * thresholds[2 * i + 1] / 100);
        if (lowerCorrect > upperCorrect) {
            lowerCorrect = upperCorrect;
        }
        var lowerWrong = questions - lowerCorrect;

        var line1 = "<td>" + upperWrong + " - " + lowerWrong + "</td>";
        var line2 = "<td>" + lowerCorrect + " - " + upperCorrect + "</td>";

        if (upperWrong === lowerWrong) {
            line1 = "<td>" + upperWrong + "</td>";
            line2 = "<td>" + lowerCorrect + "</td>";
        }

        ct += "<tr class='omrChartRow'>" +
            "<td>" +  letters[i] +  "</td>" +
            line1 + line2 +
            "<td>" + questions + "</td></tr>";
    }

    ct += "</tr></table>";

    jQuery('.quickChartDiv').html(ct);
}

function showQuickChartUpdate() {
    var showChart = $('#showQuickChart').is(':checked');
    if (showChart) {
        $('#quickChartSection').show('fast');
    } else {
        $('#quickChartSection').hide('fast');
    }
    reportGtagEvent('showQuickChartUpdate');
}

function showChartUpdate() {
    var showChart = $('#showChart').is(':checked');
    if (showChart) {
        $('#chartSection').show('fast');
    } else {
        $('#chartSection').hide('fast');
    }
    reportGtagEvent('showChartUpdate');
}

function selectScaling(selectedScaling) {
    $('#gradingScaleContainer>button').removeClass("selected");
    $('#gradingScaleContainer button:nth-child(' + selectedScaling + ')').addClass("selected");
    scaling = selectedScaling;
    calculateResult();
}

function reportGtagEvent(eventInfo) {
    if (typeof window.gtag == 'function') {
        window.gtag('event', eventInfo, {
            'event_category': 'functionCalled'
        });
    }
}

$(document).ready(function () {
    $("#qNumber").val(100);
    $("#wrongNumber").val(0);

    $("#qNumber").on('change keyup paste', function () {
        calculateResult();
        reportGtagEvent('questionNumChange');
    });

    $("#wrongNumber").on('change keyup paste', function () {
        calculateResult();
        reportGtagEvent('wrongNumChange');
    });

    calculateResult();
    showChartUpdate();
    showQuickChartUpdate();
});