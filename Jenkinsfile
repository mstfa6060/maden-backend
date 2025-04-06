pipeline {
    agent any

    stages {
        stage('Setup') {
            steps {
                script {
                    echo "íº€ Setup iÅŸlemleri baÅŸlatÄ±lÄ±yor..."
                    sh 'dotnet restore'
                }
            }
        }

        stage('Build ErrorCodeExporter') {
            steps {
                sh 'dotnet build Jobs/SpecialPurpose/DevTasks/ErrorCodeExporter/ErrorCodeExporter.csproj --configuration Release'
                sh 'dotnet run --project Jobs/SpecialPurpose/DevTasks/ErrorCodeExporter/ErrorCodeExporter.csproj'
            }
        }

        stage('Generate ArfBlocks Docs') {
            steps {
                sh 'arfblocks-cli exec --file _devops/arfblocks-cli/hirovo.arfblocks-cli.json'
                sh 'arfblocks-cli exec --file _devops/arfblocks-cli/iam.arfblocks-cli.json'
            }
        }

        stage('Publish Artifacts') {
            steps {
                echo "í³¦ Artifaktlar hazÄ±rlanÄ±yor (opsiyonel)..."
            }
        }
    }
}
