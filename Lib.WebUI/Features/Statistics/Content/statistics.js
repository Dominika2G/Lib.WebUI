import './statistics.scss';


$(function () {
    const ctx = document.getElementById('myChart');
    const myChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: ['Dostępne', 'Wypożyczono', 'Zarezerwowano'],
            datasets: [{
                label: '# of Votes',
                data: [25, 18, 1],
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
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
    const ctx1 = document.getElementById('myChart2');
    const myChart2 = new Chart(ctx1, {
        type: 'pie',
        data: {
            labels: ['Dostępne', 'Wypożyczono', 'Zarezerwowano'],
            datasets: [{
                label: '# of Votes',
                data: [25, 18, 1],
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
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
    //Kolejny chart
    const labels = ['Poniedziałek', 'Wtorek', 'Środa', 'Czwartek', 'Piatek', 'Sobota', 'Niedziela'];

    const ctx2 = document.getElementById('myLineChart');
    const myLineChart = new Chart(ctx2, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Dni',
                data: [65, 59, 80, 81, 56, 55, 40],
                borderColor: [
                    'rgb(75, 192, 192)'
                ],
                borderWidth: 1,
                tension: 0.1,
                fill: false
            }]
        }
    });
});
