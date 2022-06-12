# DOOZY

# Kubernetes Instructions (Main)
# Create namespace
```
kubectl apply -f namespace.yml
```
# Create secrets

add secrets:
```
kubectl create secret generic mysql-posts-deployment --from-literal=MYSQL_PASSWORD="mydbpd" -n doozy
kubectl create secret generic mysql-profile-deployment --from-literal=MYSQL_PASSWORD="mydbpd" -n doozy
```

# Persistant volume claims
This claims starage on your machine
```
kubectl apply -f mysql-posts-deployment-pvc.yml
```
```
kubectl apply -f mysql-profile-deployment-pvc.yml
```
# Databases
This creates the databases needed for each service
```
kubectl apply -f mysql-posts-deployment.yml
```
```
kubectl apply -f mysql-profile-deployment.yml
```
```
kubectl apply -f api-gateway.yml
```
# Messagebus Rabbit-MQ
this creates the messagebus
```
kubectl apply -f rabbitmq-deployment.yml
```
# Services
this creates the services
```
kubectl apply -f posts-microservice-deployment.yml
```
```
kubectl apply -f profile-microservice-deployment.yml
```
# Enable automatic image pulling 
```
kubectl apply -f keel.yml
```
# Load testing (Main)
Create the testing stack (/jmeter-k8s-starterkit-master)
```
kubectl create -R -f k8s/
```
Starting the test with the desired # of slaves
```
./start_test.sh -n default -j my-scenario.jmx -i {number of slave pods)
```
View the dashboard (login:admin password: XhXUdmQ576H6e7)
```
kubectl port-forward <grafana_pod_id> 3000
```
# Create dashboard 
To access the kubernetes dashboard with CPU/GPU information follow this [tutorial](https://devopscube.com/setup-grafana-kubernetes/) the files are in the kubernetes/Dashboard folder

As to deploy the kubernetes build in dashboard 

Create the needed files
```
kubectl apply -f https://raw.githubusercontent.com/kubernetes/dashboard/v2.5.0/aio/deploy/recommended.yaml
```
Set the server live
```
kubectl proxy
```
# Database Replication (Main kubernetes/DB Replication)
Create definitions for operator
```
kubectl apply -f replication-setup.yml
```
Deploy operator
```
kubectl apply -f deploy-operator.yml
```
Create SQL Secrets for both databases
```
kubectl create secret generic  mypwdspost \
        --from-literal=rootUser=root \
        --from-literal=rootHost=% \
        --from-literal=rootPassword="root"
        
kubectl create secret generic  mypwdsprofile \
        --from-literal=rootUser=root \
        --from-literal=rootHost=% \
        --from-literal=rootPassword="root"
```
Apply the cluster files
```
kubectl apply -f profile-cluster.yml

kubectl apply -f post-cluster.yml
```

# Docker Compose (Dev)
Run the docker compose file
```bash
docker-compose build
docker-compose -f docker-compose.yml up -d
```
When the docker-compose is up.

>PostMicroservice: https://localhost:5500
>ProfileMicroservice: https://localhost:5501
>APIGatewayMicroservice: https://localhost:5501

# Authorization/Authentication
To make the application easier to test the authorization/authentication is present in the features/adding-authentication-authorization branch. Further explaination how this works can be found in the [Learning Outcomes Specefications Document](https://stichtingfontys-my.sharepoint.com/:w:/r/personal/439702_student_fontys_nl/Documents/Semester%206/Delivery/Learning%20Outcomes%20Specefications.docx?d=wa5edd439ea4141a88794b41aaa1d8128&csf=1&web=1&e=2705NC)

