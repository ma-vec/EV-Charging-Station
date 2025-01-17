# EV-Charging-Station
Simulatore WinForm C# di una stazione di ricarica per auto elettriche dotata di un certo numero di colonnine (ognuna delle quali è dotata di un singolo attacco). Il numero di automobili e colonnine, così come la tipologia di queste ultime sono a discrezione dell'utente. E' inoltre possibile scegliere la quantità di energia residua di ogni auto all'arrivo (0-100, SoC - State of Charge).
# Eventi e concorrenza
Nella simulazione si verifica una concorrenza di accesso alle colonnine (risorse limitate) qualora il numero di auto che desiderano caricare sia maggiore delle colonnine libere in quall'istante. Conseguentemente una o più auto sono poste in attesa e collegate automaticamente alla prima presa liberatasi. Nella programmmazione ogni auto è un thread e l'accesso alle risorse Station è gestito tramite SemaphoreSlim.
# BMS (Battery Management System)
Tutti i veicoli elettrici sono dotati di un sistema che punta a preservare il pacco batteria quando ad esempio non si trova in condizioni ottimali per accettare una elevata potenza di ricarica. E' comune infatti che sopra il 80% di carica, la potenza che l'auto accetta diminuisca gradualmente, dipendendo anche dalla potenza massima della colonnina stessa. In altre parole, maggiore è la potenza che la colonnina può erogare, maggiore sarà la diminuzione apportata dal BMS. Questa simulazione propone una logica BMS semplificata a scopo dimostrativo.
# Tipologie di Stazioni
Come nella realtà, l'utente può scegliere tra diverse potenze di colonnine da aggiungere che modificheranno di conseguenza la velocità di carica ed il corrispettivo tempo per il completamento.
<li>Quick (22 kW)</li>
<li>Fast (50 kW)</li>
<li>HPC (150 kW)</li>
Nota: il tempo è accelerato e non realistico
