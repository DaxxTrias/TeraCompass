﻿// Unknown Author and License

using System;

namespace TeraCompass.Tera.Core.Sniffing.Crypt
{
    public class Session
    {
        private static Session _instance;
        public byte[] ClientKey1 = new byte[128];
        public byte[] ClientKey2 = new byte[128];
        public byte[] DecryptKey = new byte[128];
        protected Cryptor Decryptor;

        public byte[] EncryptKey = new byte[128];
        protected Cryptor Encryptor;
        public byte[] ServerKey1 = new byte[128];
        public byte[] ServerKey2 = new byte[128];

        public byte[] TmpKey1 = new byte[128];
        public byte[] TmpKey2 = new byte[128];


        private Session()
        {
        }

        public static Session Instance => _instance ?? (_instance = new Session());

        public void Init()
        {
            TmpKey1 = Utils.ShiftKey(ServerKey1, 67);
            TmpKey2 = Utils.XorKey(TmpKey1, ClientKey1);
            TmpKey1 = Utils.ShiftKey(ClientKey2, 29, false);
            DecryptKey = Utils.XorKey(TmpKey1, TmpKey2);
            Decryptor = new Cryptor(DecryptKey);
            TmpKey1 = Utils.ShiftKey(ServerKey2, 41);
            Decryptor.ApplyCryptor(TmpKey1, 128);
            EncryptKey = new byte[128];
            Buffer.BlockCopy(TmpKey1, 0, EncryptKey, 0, 128);
            Encryptor = new Cryptor(EncryptKey);
        }

        public void Encrypt(byte[] data)
        {
            Encryptor.ApplyCryptor(data, data.Length);
        }

        public void Decrypt(byte[] data)
        {
            Decryptor.ApplyCryptor(data, data.Length);
        }
    }
}