# New CDN iTaas Challenge - Guilherme

### Clone the GIT repository available at: https://github.com/gsennaura/iTassChallenge.git ~ [GIT]
```sh
git clone https://github.com/gsennaura/iTassChallenge.git
cd .\iTassChallenge\app\
git checkout main
git pull
```

### Important Requirements ~ [REQUIREMENTS]
```sh
1: install .NET SDK: https://dotnet.microsoft.com/en-us/download
2: check if .NET is installed correctly: dotnet --version
```

### run the converter  ~ [C#]
```sh
1: Make sure you have an URL in a 'MINHA CDN' log format. For example: https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt
2: Check existence of 'logs directory' inside 'app'
3: Access 'app' directory
4: Run Console Application using the following command: dotnet run (sourceUrl) (nameFile). 
    4.1: (SourceUrl): Link that contains a downloadable 'Minha CDN' log
    4.2: (nameFile): O nome do arquivo que será usado para salvar o log para download.
    4.3: Example: dotnet run https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt minhaCdn1.txt
```
