const API_URL = "http://localhost:5185/api/plugins";

const output = document.getElementById('output');

async function callPlugin(name, renderFn) {
  output.innerHTML = '<div class="loading">Cargando...</div>';
  try {
    const res = await fetch(`${API_URL}/${name}`);
    if (!res.ok) throw new Error('No se pudo conectar con la API');
    const data = await res.json();
    output.innerHTML = renderFn(data);
  } catch (err) {
    output.innerHTML = `<div class="error">⚠️ ${err.message}</div>`;
  }
}

function renderMatchScore(data) {
  return `
    <div class="card">
      <div class="card-title">Último resultado</div>
      <div class="match-row">
        <span class="team">${data.local}</span>
        <span class="score">${data.marcador}</span>
        <span class="team">${data.visitante}</span>
      </div>
    </div>
  `;
}

function renderRanking(data) {
  const items = data.map(team => `<li>${team}</li>`).join('');
  return `
    <div class="card">
      <div class="card-title">Ranking actual</div>
      <ul class="ranking-list">${items}</ul>
    </div>
  `;
}

function renderPrediction(data) {
  const confidence = parseInt(data.confianza) || 0;
  return `
    <div class="card">
      <div class="card-title">Predicción del campeón</div>
      <div class="prediction-main">
        <div class="prediction-team">🏅 ${data.campeon}</div>
      </div>
      <div class="confidence-bar">
        <div class="confidence-fill" style="width:${confidence}%"></div>
      </div>
      <div class="confidence-label">${data.confianza} de confianza</div>
    </div>
  `;
}

document.getElementById('btnScore').addEventListener('click', () => callPlugin('matchscore', renderMatchScore));
document.getElementById('btnRanking').addEventListener('click', () => callPlugin('ranking', renderRanking));
document.getElementById('btnPrediction').addEventListener('click', () => callPlugin('prediction', renderPrediction));