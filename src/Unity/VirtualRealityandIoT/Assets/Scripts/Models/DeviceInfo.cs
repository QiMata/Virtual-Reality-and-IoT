using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Models
{
    class DeviceInfo
    {
        public string DeviceId { get; set; }

        protected bool Equals(DeviceInfo other)
        {
            return string.Equals(DeviceId, other.DeviceId);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((DeviceInfo) obj);
        }

        public override int GetHashCode()
        {
            return (DeviceId != null ? DeviceId.GetHashCode() : 0);
        }

        public static bool operator ==(DeviceInfo left, DeviceInfo right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DeviceInfo left, DeviceInfo right)
        {
            return !Equals(left, right);
        }

        private sealed class DeviceIdEqualityComparer : IEqualityComparer<DeviceInfo>
        {
            public bool Equals(DeviceInfo x, DeviceInfo y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.DeviceId, y.DeviceId);
            }

            public int GetHashCode(DeviceInfo obj)
            {
                return (obj.DeviceId != null ? obj.DeviceId.GetHashCode() : 0);
            }
        }

        private static readonly IEqualityComparer<DeviceInfo> DeviceIdComparerInstance = new DeviceIdEqualityComparer();

        public static IEqualityComparer<DeviceInfo> DeviceIdComparer
        {
            get { return DeviceIdComparerInstance; }
        }
    }
}
