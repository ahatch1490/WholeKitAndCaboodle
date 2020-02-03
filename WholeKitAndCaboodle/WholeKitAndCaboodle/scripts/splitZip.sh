while IFS=, read -r col1 col2
do
    echo $col1 | sed -e 's/^"//' -e 's/"$//' | sed -e 's/^[0-9]*//'  
done < ../data/address.csv 


