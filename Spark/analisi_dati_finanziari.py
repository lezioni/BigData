from pyspark import SparkConf, SparkContext
from pyspark.sql import SparkSession
from pyspark.sql.functions import *

conf = SparkConf()
conf.setMaster("local")
conf.setAppName("ITS Sample App")
conf.set('spark.logConf', 'True') 
#conf.set("spark.executor.memory", "1g")

sc = SparkContext(conf = conf)
sc.setLogLevel("Warn")

spark = SparkSession.builder.getOrCreate()

# Configuration 
# filename = "/home/its/sample_data/movimenti.csv"
filename = "/home/mauro/sample_data/movimenti.csv"

print("Reading file " + filename)


mvm1 = spark.read.options(header=True).csv(filename)
print(' ')
print('Importazione da csv senza opzioni')
print(mvm1.printSchema())

print(' ')
mvm2 = spark.read.options(header=True, sep=';', inferSchema=True).csv('/mnt/c/temp/its_bigdata/movimenti.csv')
print('Importazione da csv con opzione inferSchema e separatore custom')
print(mvm2.printSchema())

print('Importazione da csv con schema custom')
user_schema = 'cognome STRING, nome STRING, data TIMESTAMP, importo INTEGER'
# df = spark.read.csv(path=filename, schema = user_schema, sep=';', dateFormat='MM/dd/yyyy',timestampFormat='yyyy/MM/dd HH:mm:ss')
mvm3 = spark.read.csv(path=filename, schema = user_schema, sep=';', timestampFormat='yyyy/MM/dd HH:mm:ss', header=True)
print(mvm3.printSchema())

print('Movimenti totali: ' + str(mvm3.count()))

print(' ')
print('Le 20 persone con saldo maggiore')
print(mvm3.groupBy('cognome','nome').sum('importo').orderBy('sum(importo)', ascending=False).show())


print(' ')
print('Le 20 persone con saldo minore')
print(mvm3.groupBy('cognome','nome').sum('importo').orderBy('sum(importo)').show())


print(' ')
print('Movimenti per anno')
print(mvm3.groupBy(year('data').alias('anno')).sum('importo').orderBy('anno').show())


print(' ')
print('Operazioni sopra soglia')
print( mvm3.filter( (mvm3.importo>50000 )| (mvm3.importo<-50000)).orderBy('importo', ascending=False).show())

print(' ')
print('Operazioni sospette')
print(mvm3.groupBy('cognome','nome').avg('importo').orderBy('avg(importo)').show())
print(mvm3.groupBy('cognome','nome').avg('importo').orderBy('avg(importo)', ascending=False).show())

spark.stop()