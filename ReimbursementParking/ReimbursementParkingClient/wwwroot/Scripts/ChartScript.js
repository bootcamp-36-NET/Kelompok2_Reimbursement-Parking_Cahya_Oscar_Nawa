am4core.useTheme(am4themes_animated);

var Pie = am4core.createFromConfig({
    "innerRadius": "50%",

    "dataSource": {
        "url": "/chart/LoadPie",
        "parser": {
            "type": "JSONParser",
        },
        "reloadFrequency": 5000,
    },

    // Create series
    "series": [{
        "type": "PieSeries",
        "dataFields": {
            "value": "total",
            "category": "VechicleType",
        },
        "slices": {
            "cornerRadius": 12,
            "innerCornerRadius": 9
        },
        "hiddenState": {
            "properties": {
                // this creates initial animation
                "opacity": 1,
                "endAngle": -90,
                "startAngle": -90
            }
        },
        "children": [{
            "type": "Label",
            "forceCreate": true,
            "text": "Type",
            "horizontalCenter": "middle",
            "verticalCenter": "middle",
            "fontSize": 20
        }]
    }],

    // Add legend
    "legend": {},

}, "pieChart", am4charts.PieChart);

am4core.ready(function () {

    // Themes begin
    am4core.useTheme(am4themes_animated);
    // Themes end

    // Create chart instance
    var chart = am4core.create("barChart", am4charts.XYChart);
    chart.scrollbarX = new am4core.Scrollbar();

    // Add data
    chart.dataSource.url = "/chart/LoadPie";

    // Create axes
    var categoryAxis = chart.xAxes.push(new am4charts.CategoryAxis());
    categoryAxis.dataFields.category = "VechicleType";
    categoryAxis.renderer.grid.template.location = 0;
    categoryAxis.renderer.minGridDistance = 30;
    categoryAxis.renderer.labels.template.horizontalCenter = "right";
    categoryAxis.renderer.labels.template.verticalCenter = "middle";
    categoryAxis.renderer.labels.template.rotation = 270;
    categoryAxis.tooltip.disabled = true;
    categoryAxis.renderer.minHeight = 110;

    var valueAxis = chart.yAxes.push(new am4charts.ValueAxis());
    valueAxis.renderer.minWidth = 50;

    // Create series
    var series = chart.series.push(new am4charts.ColumnSeries());
    series.sequencedInterpolation = true;
    series.dataFields.valueY = "total";
    series.dataFields.categoryX = "VechicleType";
    series.tooltipText = "[{categoryX}: bold]{valueY}[/]";
    series.columns.template.strokeWidth = 0;

    series.tooltip.pointerOrientation = "vertical";

    series.columns.template.column.cornerRadiusTopLeft = 10;
    series.columns.template.column.cornerRadiusTopRight = 10;
    series.columns.template.column.fillOpacity = 0.8;

    // on hover, make corner radiuses bigger
    var hoverState = series.columns.template.column.states.create("hover");
    hoverState.properties.cornerRadiusTopLeft = 0;
    hoverState.properties.cornerRadiusTopRight = 0;
    hoverState.properties.fillOpacity = 1;

    series.columns.template.adapter.add("fill", function (fill, target) {
        return chart.colors.getIndex(target.dataItem.index);
    });

    // Cursor
    chart.cursor = new am4charts.XYCursor();

}); // end am4core.ready()

$(document).ready(function () {
    $.ajax({
        url: "/chart/LoadBar",
        method: "GET",
        dataType: 'JSON',
        success: function (data) {
            console.log(data);
            var hasilA = [];
            var hasilB = [];

            for (var i in data) {
                hasilA.push(data[i].ManagerResponseTime);
                hasilB.push(data[i].total);
            }

            var chartdata = {
                labels: hasilA,
                datasets: [
                    {
                        label: 'Values',
                        //backgroundColor: 'rgba(200, 200, 200, 0.75)',
                        //borderColor: 'rgba(200, 200, 200, 0.75)',
                        //hoverBackgroundColor: 'rgba(200, 200, 200, 1)',
                        //hoverBorderColor: 'rgba(200, 200, 200, 1)',
                        data: Object.values(hasilB),
                    }
                ]
            };

            var ctx = $("#myChart");

            var barGraph = new Chart(ctx, {
                type: 'bar',
                data: chartdata,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)'
                ],
                borderWidth: 1,
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
        },
        error: function (data) {
            console.log(data);
        }
    });
});

$('#downloadPdf').click(function (event) {
    // get size of report page
    var reportPageHeight = $('#reportPage').innerHeight();
    var reportPageWidth = $('#reportPage').innerWidth();

    // create a new canvas object that we will populate with all other canvas objects
    var pdfCanvas = $('<canvas />').attr({
        id: "canvaspdf",
        width: reportPageWidth,
        height: reportPageHeight
    });

    // keep track canvas position
    var pdfctx = $(pdfCanvas)[0].getContext('2d');
    var pdfctxX = 0;
    var pdfctxY = 0;
    var buffer = 100;

    // for each chart.js chart
    $("canvas").each(function (index) {
        // get the chart height/width
        var canvasHeight = $(this).innerHeight();
        var canvasWidth = $(this).innerWidth();

        // draw the chart into the new canvas
        pdfctx.drawImage($(this)[0], pdfctxX, pdfctxY, canvasWidth, canvasHeight);
        pdfctxX += canvasWidth + buffer;

        // our report page is in a grid pattern so replicate that in the new canvas
        if (index % 2 === 1) {
            pdfctxX = 0;
            pdfctxY += canvasHeight + buffer;
        }
    });

    // create new pdf and add our new canvas as an image
    var pdf = new jsPDF('l', 'pt', [reportPageWidth, reportPageHeight]);
    pdf.addImage($(pdfCanvas)[0], 'PNG', 0, 0);

    // download the pdf
    pdf.save('filename.pdf');
});
function exportPDF() {
    barChart.exporting.export("pdf");
}