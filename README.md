![Webhookachu logo](./webhookachu-icon.jpg)

# Webhookachu

**Webhookachu** is a lightweight .NET 8 application that helps you receive, log, and simulate webhooks — all from a local or cloud-hosted endpoint.

> `Webhookachu` — because every webhook deserves to be caught ⚡

---

## 🎯 What it's for

- Catching and logging incoming webhook requests,
- Viewing recent webhook payloads in raw JSON format,
- Simulating outbound webhook requests to any URL (test integrations),
- Quickly validating that webhooks hit the expected target.

---

## 💡 Who it's for

For developers, integrators, QA engineers, and DevOps who need a transparent and minimal webhook utility for testing, debugging, or local development.

---

## 🚀 Endpoints

| Method | Path              | Description                                  |
|--------|-------------------|----------------------------------------------|
| `POST` | `/log`            | Receive and log incoming webhook request     |
| `GET`  | `/logs?last=N`    | View the last N logged requests as text      |
| `POST` | `/simulateWebhook`| Send a webhook (POST) with any JSON payload  |

---

### 📥 Example: Send webhook to this app

Use cURL or any HTTP client to send a test webhook to the logger:

```bash
curl http://localhost:5158/log \
  -H "Content-Type: application/json" \
  -d '{ "event": "UserCreated", "userId": 123 }'
```

### 📤 Example: Simulate webhook to external URL

Trigger a webhook from this app to another service: 
```
POST /simulateWebhook
Content-Type: application/json

{
  "url": "https://webhook.site/your-id",
  "payload": {
    "type": "InvoiceGenerated",
    "amount": 199.99
  }
}
```

### ⚙️ Configuration
The app uses appsettings.json for basic settings like file path:

```json
{
  "WebhookLogStorage": {
    "LogFilePath": "logs.txt"
  }
}
```

### 🧪 Running Locally
```
dotnet run --project Webhookachu
```