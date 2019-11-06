# Authentication

To add authentication to the service, simply provide the following json in your appsettings.json.

```text
"ServiceBlock": {
    "Security": {
        "Domain": "https://<YOUR_IDP_URL>/",
        "ApiIdentifier": "<YOUR_API_ID>",
        "ClientId": "<YOUR_CLIENT_ID>",
        "Scopes": {
            "email": "Example Scope"
        }
    }
}
```

Authentication will be activated for all your resources.

