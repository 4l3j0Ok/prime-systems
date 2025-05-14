#!/bin/bash
read -p "Ingresa el path del archivo mdb: " mdb_file
mdb-schema "$mdb_file" mysql > ${mdb_file%.mdb}.sql
