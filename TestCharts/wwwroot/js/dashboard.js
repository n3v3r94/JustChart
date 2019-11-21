
(function () {

    //var chart = [
    //    myChart0 = {},
    //    myChart1 = {},
    //    myChart2 = {},
    //];

    var myChart = {};
    var color = ['rgb(255, 99, 132,0.5)', 'rgb(255, 159, 64,0.5)', 'rgb(255, 205, 86,0.5)', 'rgb(75, 192, 192,0.5)', 'rgb(54, 162, 235,0.5)', 'rgb(153, 102, 255,0.5)', 'rgb(201, 203, 207,0.5)'];
    var borderColors = [
        '#f67019',
        '#4dc9f6',
        '#f53794',
        '#537bc4',
        '#acc236',
        '#166a8f',
        '#00a950',
        '#58595b',
        '#8549ba'
    ];

    $.ajax({
        url: "Dashboard/GetDashboardById",
        type: "GET",
        data: { id: "1" },
        contentType: "application/json",
        dataType: "json",
        success: function (data) {

            for (var i = 0; i < data.dashlets.length; i++) {
                (function (i) {
                    var test = data.dashlets[i];
                    $.ajax({
                        url: "Dashboard/GetDashletData",
                        type: "POST",
                        contentType: "application/json",
                        data: JSON.stringify(test),
                        beforeSend: function () {
                            $("#my-chart-api-" + i).append('<div class="lds-roller"><div></div><div></div><div></div><div></div><div></div><div></div><div></div><div></div></div>')
                           
                        },
                        success: function (response) {
                            var currentChart = JSON.parse(response)
                            init(i, test.typeOfChart);
                            for (var j = 0; j < currentChart.length; j++) {
                                tempChart = currentChart[j];
                                var newDataset = {
                                    label: tempChart.alias,
                                    labels: tempChart.count,
                                    backgroundColor: color[j % 6],
                                    borderColor: borderColors[j % 6],
                                    borderWidth: 2,
                                    data: [],
                                    spanGaps: true,
                                };

                                myChart.data.datasets.push(newDataset);
                                myChart.data.datasets[j].data.push(tempChart.count);
                            }
                            myChart.update()
                        },
                        complete: function () {
                            $("#my-chart-api-" + i).remove();
                        },
                    });
                })(i);
            }


        }
    });

    var options = {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }]
        },
        title: {
            fontSize: 18,
            display: true,
            text: 'Charts of Doctors',
            position: 'top'
        },
        animation: {
            duration: 5000,
            onProgress: function (animation) {
            },
        }
    };

    function init(id, type) {

        var ctx = document.getElementById('myChartAPI' + id);
        myChart = new Chart(ctx, {
            type: type,
            data: [{
                datasets: [{}]
            }],
            options: options
        });

    }

})();