
# Sagre e Fiere in Lombardia

**“Sagre e Fiere in Lombardia”** è un progetto MVC sviluppato in .NET 6 con Visual Studio, che consente di esplorare un elenco aggiornato di eventi di tipo sagre e fiere distribuiti sul territorio lombardo.  
I dati sono ottenuti da un dataset JSON fornito da *www.dati.lombardia.it* e visualizzati tramite un'interfaccia web.  
L'applicazione offre funzionalità di ricerca sia per filtrare gli eventi sia per filtrare i comuni, con una gestione della paginazione e un servizio SOAP (realizzato tramite **SoapCore**) per ottenere le informazioni tramite il web service e poterle mostrare correttamente nell'interfaccia.

L'intero progetto è containerizzato con Docker per garantire portabilità e facilità di distribuzione.


## 🚀 Funzionalità

- 🔍 **Visualizzazione Eventi:** Elenco completo degli eventi con dettagli rilevanti (Nome evento, edizione e data di inizio e fine evento) e la possibilità di accedere a google maps per ottenere le indicazioni per raggiungere il luogo dell'evento.
- 📑 **Ricerca e Filtro :** Filtra gli eventi e i comuni per ottenere le informazioni desiderate.
- 📡 **Servizio SOAP:** Endpoint SOAP (`/EventService.cs`) per recuperare i dati dall'endpoint API JSON.

## 🛠️ Tecnologie utilizzate

- **.NET 6** – Framework di sviluppo backend per applicazioni moderne.
- **MVC** – Architettura Model-View-Controller.
- **SoapCore** – Libreria per la creazione di servizi SOAP in ambiente .NET.
- **HttpClient** – Utilizzato per effettuare la chiamata GET all'API JSON.
- **Newtonsoft.Json** – Per il parsing del JSON.
- **Docker** – Containerizzazione dell’applicazione per l’esecuzione su qualsiasi ambiente.

## 💻 Struttura del progetto

- `Models/Event.cs` – Classe che rappresenta i dati ottenibili dalla lettura dell'API JSON.
- `Controllers/EventController.cs` – Gestione della view e della logica con l'utilizzo del servizio SOAP creato.
- `Views/Index.cshtml` – File Razor (.cshtml) per la presentazione dei dati all'utente.
- `Services/EventService.cs` – Contiene la logica di consumo dei dati da sorgente esterna.
- `ServizioSOAP/LombardiaEventsService.cs` – Espone metodi come `GetAllEvents`, `GetEventsByComune(string queryParam)`, `GetEventsByName(string queryParam)`.
- `wwwroot/` – Risorse statiche come CSS, JS, immagini.
- `appsettings.json` – File di configurazione del progetto.
- `Dockerfile` – File per la containerizzazione del progetto.

## ✨ Stile e Layout

- **Bootstrap 5** – Utilizzato per il design dell'interfaccia web.
- **Paginazione personalizzata** – Navigazione fluida tra le pagine di risultati.

---

## 📦 Installazione
   1. **Clonare il repository:**
      ```bash
      git clone https://github.com/Anvo00/Sagre-FiereLombardia.git
   2. **Aprire il Progetto in Visual Studio:**
      - Apri Visual Studio.
      - Seleziona "Apri un progetto o una soluzione".
      - Naviga fino alla cartella del progetto e seleziona il file .sln.
   
   3. **Eseguire l'Applicazione:**
   Premi F5 o clicca su "Esegui" per avviare l'applicazione in modalità debug.

   5. **Accesso al Servizio SOAP:**
   Per accedere al servizio SOAP, vai a http://localhost:5053/LombardiaEventsService.wsdl.

## 🐳 Docker
   1. **Creare l'immagine Docker:**
      ```bash
      docker build -t sagreFiereLombardia/web -f \Dockerfile\ ..
   2. **Eseguire il container Docker:**
      ```bash
      docker run -d --name sagreFiereLombardia/web -p 8080:80 sagreFiereLombardia/web
   
   Il servizio Docker sarà accessibile all'indirizzo [http://localhost:8080](http://localhost:8080).

## 🤝 Membri del gruppo
   - **Antonacci Alessandra**
   - **Giacobelli Vito**
