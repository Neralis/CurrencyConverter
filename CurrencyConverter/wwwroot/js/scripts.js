async function fetchCurrencyRates() {
    const response = await fetch('https://localhost:7004/api/currencyrate/');
    const data = await response.json();
    return data;
}

async function convertCurrency() {
    const fromCurrency = document.getElementById('fromCurrency').value;
    const toCurrency = document.getElementById('toCurrency').value;
    const fromAmount = parseFloat(document.getElementById('fromAmount').value.replace(',', '.'));
    const currencyRates = await fetchCurrencyRates();

    const currencyUnits = {
        "AUD": 1, "AZN": 1, "AMD": 100, "BYN": 1, "BGN": 1, "BRL": 1,
        "HUF": 100, "KRW": 1000, "VND": 10000, "HKD": 1, "GEL": 1,
        "DKK": 1, "AED": 1, "USD": 1, "EUR": 1, "EGP": 10, "INR": 10,
        "IDR": 10000, "KZT": 100, "CAD": 1, "QAR": 1, "KGS": 10, "CNY": 1,
        "MDL": 10, "NZD": 1, "TMT": 1, "NOK": 10, "PLN": 1, "RON": 1,
        "XDR": 1, "RSD": 100, "SGD": 1, "TJS": 10, "THB": 10, "TRY": 10,
        "UZS": 10000, "UAH": 10, "GBP": 1, "CZK": 10, "SEK": 10, "CHF": 1,
        "ZAR": 10, "JPY": 100, "RUB": 1
    };

    const fromRate = fromCurrency === 'RUB' ? 1 : parseFloat(currencyRates[fromCurrency].replace(',', '.')) / currencyUnits[fromCurrency];
    const toRate = toCurrency === 'RUB' ? 1 : parseFloat(currencyRates[toCurrency].replace(',', '.')) / currencyUnits[toCurrency];

    if (isNaN(fromAmount) || isNaN(fromRate) || isNaN(toRate)) {
        alert('Invalid input or currency rate');
        return;
    }

    let result;
    if (fromCurrency === 'RUB') {
        result = fromAmount / toRate;
    } else if (toCurrency === 'RUB') {
        result = fromAmount * fromRate;
    } else {
        result = (fromAmount * fromRate) / toRate;
    }

    document.getElementById('toAmount').value = result.toFixed(2);
}

// Обработчики событий для изменения полей ввода и select'ов
document.getElementById('fromAmount').addEventListener('input', convertCurrency);
document.getElementById('fromCurrency').addEventListener('change', convertCurrency);
document.getElementById('toCurrency').addEventListener('change', convertCurrency);