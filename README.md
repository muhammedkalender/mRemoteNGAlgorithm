## This application usage for en-decrypt directly mRemoteNG passwords

### Project has been written for Mesut Komiser but everybody can use if wants

----

**Platform: .NET 4.8**

**Method: AES-128 Bit**

----

## Algorithms
### Decrypt
```
AES_DECRYPT(MD5_DECODE($HASHED_PASSWORD), MD5($MASTER_PASSWORD))
```
### Encrypt
```
MD5(AES_ENCRYPT($PLAIN_PASSWORD, MD5($MASTER_PASSWORD)))
```