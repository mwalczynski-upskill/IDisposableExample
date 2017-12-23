using System;
using System.IO;
using System.Threading.Tasks;

namespace IDisposableExample
{
    public class MyFileReader : IDisposable
    {
        private readonly StreamReader _reader;
        private bool _alreadyDisposed;

        public MyFileReader(string fileName)
        {
            _reader = new StreamReader(fileName);
        }

        public void Dispose()
        {
            if (!_alreadyDisposed)
            {
                _reader.Dispose();
                _alreadyDisposed = true;
            }
        }

        public string ReadFromFile()
        {
            CheckIfAlreadyDisposed();
            var fileContent = _reader.ReadToEnd();
            return fileContent;
        }

        private void CheckIfAlreadyDisposed()
        {
            if (_alreadyDisposed)
            {
                throw new ObjectDisposedException("Already disposed");
            }
        }
    }
}
