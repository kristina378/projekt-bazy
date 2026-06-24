import random
import csv
from faker import Faker

fake = Faker()

locations = [(i,fake.unique.city()) for i in range(1,31)] # generujemy 30 randowych miast razem z id
with open('lokalizacje.csv', mode = 'w', newline = '') as file:
    writer = csv.writer(file)
    writer.writerow(['ID_Lokalizacji', 'Miasto']) # Zapis nagłówków
    writer.writerows(locations) # Zapis wszystkich danych z listy


devices = []
deviceType = ['Router', 'Switch', 'Firewall', 'Server']

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
