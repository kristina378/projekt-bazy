import random
import csv
from faker import Faker

def generate_csv_locations(fake:Faker)->list:

    locations = [(i,fake.unique.city()) for i in range(1,31)] # generujemy 30 randowych miast razem z id

    with open('lokalizacje.csv', mode = 'w', newline = '') as file:
        writer = csv.writer(file)
        writer.writerow(['ID_Lokalizacji', 'Miasto']) # Zapis nagłówków
        writer.writerows(locations) # Zapis wszystkich danych z listy

    return locations




def generate_csv_devices(fake:Faker,locations:list)->list:

    deviceType = ['Router', 'Switch', 'Firewall', 'Server']
    devices = []
    

    randomIp = fake.ipv4()
    # row = (device_id, device_type,ip, location_id, parent_device_id)
    row:tuple = (1, random.choice(deviceType), randomIp,(random.choice(locations))[0], None)
    devices.append(row)

    for id in range(2,20001):

        randomIp = fake.ipv4()
        parentId = random.randint(1,id - 1)

        row = (id, random.choice(deviceType), randomIp, (random.choice(locations))[0], parentId)
        devices.append(row)

    with open('urzadzenia.csv', mode = 'w', newline = '') as file:
        writer = csv.writer(file)
        writer.writerow(['ID_Urzadzenia', 'Typ_Urzadzenia', 'Adres_IP','ID_Lokalizacji','ID_Rodzica']) # Zapis nagłówków
        writer.writerows(devices) # Zapis wszystkich danych z listy

    return devices

def generate_csv_graph_relations(fake:Faker,devices:list)->list:

    graph:list = []
    edgeId = 1
    for device in devices[1:]:
        newRelation = (edgeId,device[0], device[4], random.randint(1,50))
        graph.append(newRelation)
        edgeId += 1

    for indx in range(2,40001):

        randomIndex1 = random.randint(1,20000)

        randomIndex2 = randomIndex1
        while (randomIndex2 == randomIndex1):
            randomIndex2 = random.randint(1, 20000)

        newRelation = (edgeId,randomIndex1, randomIndex2, random.randint(10,50))
        graph.append(newRelation)
        edgeId += 1

    with open('krawedzie.csv', mode = 'w', newline = '') as file:
        writer = csv.writer(file)
        writer.writerow(['ID_Krawedzi','ID_Zrodla','ID_Celu','Opoznienie_ms']) # Zapis nagłówków
        writer.writerows(graph) # Zapis wszystkich danych z listy

    return graph




def generate_csv_logs(fake:Faker)->list:
    status = ['OK','TIMEOUT','ERROR']
    logs:list = []

    for indx in range(1,400001):

        randomDeviceId = random.randint(1,20000)
        row = (indx,randomDeviceId,fake.date_time_this_month(),random.randint(0,1000),random.choice(status))

        logs.append(row)

    with open('logi.csv', mode = 'w', newline = '') as file:
        writer = csv.writer(file)
        writer.writerow(['ID_Logu','ID_Urzadzenia','Data','Ping','Status']) 
        writer.writerows(logs)
    
    return logs


if(__name__ == "__main__"):

    fake = Faker()

    locations = generate_csv_locations(fake)
    devices = generate_csv_devices(fake,locations)
    graph = generate_csv_graph_relations(fake,devices)
    logs = generate_csv_logs(fake)


