if [ -z "$COSMOS_DB_ACCOUNT" ]; then
    echo "Set COSMOS_DB_ACCOUNT variable"
    exit 1
fi
if [ -z "$COSMOS_DB_KEY" ]; then
    echo "Set COSMOS_DB_KEY variable"
    exit 1
fi

kubectl --namespace cosmosdb create secret generic cosmos-settings \
        --from-literal=Account="$COSMOS_DB_ACCOUNT" \
        --from-literal=Key="$COSMOS_DB_KEY" \
        --from-literal=DatabaseName="sample-sql-db" \
        --from-literal=ContainerName="sample-sql-container"
