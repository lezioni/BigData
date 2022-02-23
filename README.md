# MapReduce








# Primo esercizio

## Conteggio parole

Input: file di testo

Output: numero di occorrenze di ciascuna parola presente nel file



Input

```
Sopra la lama la barba canta
Sotto la lama la barba crepa
```

Output

```
Sopra, 1
La, 4
Lama, 2
Barba, 2
Canta, 1
Sotto, 1
Crepa, 1
```

Per usare i programmi con Hadoop streaming pubblicare i progetti con target runtime `linux-x64`, e se il runtime .NET non è installato aggiungere l'opzione deployment mode `Self-contained`

Copiare sul cluster il file di input

```
hdfs dfs -put /local_file_name /remote_file_name
```

dopo aver avviato i servizi necessari con `start-dfs.sh` e `start-yarn.sh` eseguire

```shell
mapred streaming -input /input.txt -output /conteggio_parole -mapper ./Map -reducer ./Reduce -file ./Map -file ./Reduce
```





