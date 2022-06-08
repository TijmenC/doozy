# doozy

# Create namespace
```
kubectl apply -f namespace.yaml
```
# Create secrets

add secrets:
```
kubectl create secret generic table-mysql --from-literal=MYSQL_PASSWORD="mydbpd"
```

# Persistant volume claims
This claims starage on your machine
```
kubectl apply -f mysql-posts-deployment-pvc.yaml
```
```
kubectl apply -f mysql-profile-deployment-pvc.yaml
```
# Databases
This creates the databases needed for each service
```
kubectl apply -f mysql-posts-deployment.yaml
```
```
kubectl apply -f mysql-profile-deployment.yaml
```
# Messagebus Rabbit-MQ
this creates the messagebus
```
kubectl apply -f rabbitmq-deployment.yaml
```
# Services
this creates the services
```
kubectl apply -f posts-microservice-deployment.yaml
```
```
kubectl apply -f profile-microservice-deployment.yaml
```
 
