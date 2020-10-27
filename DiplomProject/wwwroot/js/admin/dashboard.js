/*horizontalBar*/ 
var ctx = document.getElementById('myChartBar').getContext('2d');
var myBarChart = new Chart(ctx, {
    type: 'horizontalBar',
    //data: data,
    data: [20, 10],
    options: options,
    datasets: [{
        barPercentage: 0.5,
        barThickness: 6,
        maxBarThickness: 8,
        minBarLength: 2,
        data: [10, 20, 30, 40, 50, 60, 70]
    }]
});