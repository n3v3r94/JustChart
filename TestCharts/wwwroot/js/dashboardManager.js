
(function (dashboardManager, $) {

    var myChart = [{}, {}, {}, {},];

    dashboardManager.getDashboardById = function (id) {
        $.ajax({
            url: "Dashboard/GetShortDashboardById",
            type: "GET",
            contentType: "application/json",
            data: { id: id },
            beforeSend: function () {

            },
            success: function (response) {
                let isContainer = checkExistingContainer(response.id)
                if (!isContainer) {
                    removeContainer();
                    createContainer(response.id);
                }

                for (var i = 0; i < response.dashlets.length; i++) {
                    (function (i) {
                        getDashletInfo(response.id, response.dashlets[i].id)
                    })(i);
                }


            },
            complete: function () {

            },
        });
    }

    function getDashletInfo(dashboardId, dashletId) {
        (function (dashboardId, dashletId) {
            $.ajax({
                url: "Dashboard/GetDashletInfo",
                type: "GET",
                contentType: "application/json",
                data: {
                    dashboardId: dashboardId,
                    dashletId: dashletId,
                },
                success: function (dasheltInfo) {

                    createDashletContainer(dasheltInfo)
                },

            });
        })(dashboardId, dashletId);
    }

    function checkExistingContainer(dashboardId) {
        if ($(".dashboar-container").length) {
            if ($("#dashboar-container-" + dashboardId).length) {
                return true;
            }
            else {
                return false;
            }
        }
        else {
            return false;
        }
    }

    function removeContainer() {
        if ($(".main-container-dashboard").length) {
            $("#main-container-dashboard").remove();
        }
    }

    function createContainer(parrentId) {
        let $container = '<div class="row main-container-dashboard" id="main-container-dashboard"> </div>'
        $(".main-dashboard").append($container);
    }

    function createDashletContainer(dashetInfo) {
        let $dashletHTML = '<div class=" col-md-' + dashetInfo.column + '">'
            + '  <div id="loader-id-' + dashetInfo.id + '" style="align-items:center; margin:' + dashetInfo.width / 4 + '"></div>'
            + '<canvas id="dashlet-' + dashetInfo.id + '" width="' + dashetInfo.width + '" height="' + dashetInfo.height + '">  </canvas>'
            + '</div>'
        $("#main-container-dashboard").append($dashletHTML);
        intiDashlet(dashetInfo.id, dashetInfo.type);
        let parrentId = dashetInfo.parrentId;
        let dashletId = dashetInfo.id;
        (function (dashletId, parrentId) {
            $.ajax({
                url: "Dashboard/GetDashboardDashletData",
                type: "GET",
                contentType: "application/json",
                data: {
                    dashboardId: parrentId,
                    dashletId: dashletId,
                },
                success: function (dasgletData) {
                    var currentChart = JSON.parse(dasgletData)
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

                        myChart[dashletId].data.datasets.push(newDataset);
                        myChart[dashletId].data.datasets[j].data.push(tempChart.count);
                    }
                    myChart[dashletId].update()
                },
            });
        })(dashletId, parrentId);
    }


    function intiDashlet(dashletId, type) {
        var ctx = document.getElementById('dashlet-' + dashletId);
        myChart[dashletId] = new Chart(ctx, {
            type: type,
            data: [{
                datasets: [{}]
            }],
            options: options
        });
    }









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




})(window.dashboardManager = window.dashboardManager || {}, jQuery);