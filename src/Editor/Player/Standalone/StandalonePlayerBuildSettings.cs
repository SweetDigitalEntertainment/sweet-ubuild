﻿using UnityEditor;
using UnityEngine;


namespace SweetEditor.Build
{
    [CreateAssetMenu(menuName = "Build Settings/Player/Windows, Mac and Linux", order = -10)]
    public class StandalonePlayerBuildSettings : PlayerBuildSettings
    {
        [Header("PC, Mac & Linux Standalone")]
        [SerializeField] private StandalonePlatform m_TargetPlatform = default(StandalonePlatform);
        [SerializeField] private StandaloneArchitecture m_Architecture = default(StandaloneArchitecture);




        public override BuildTarget BuildTarget
        {
            get
            {
                switch (m_TargetPlatform)
                {
                    case StandalonePlatform.MacOS:
                        if (m_Architecture == StandaloneArchitecture.x86)
                        {
                            return BuildTarget.StandaloneOSXIntel;
                        }
                        else if (m_Architecture == StandaloneArchitecture.x86_64)
                        {
                            return BuildTarget.StandaloneOSXIntel64;
                        }
                        else
                        {
                            return BuildTarget.StandaloneOSXUniversal;
                        }
                    case StandalonePlatform.Linux:
                        if (m_Architecture == StandaloneArchitecture.x86)
                        {
                            return BuildTarget.StandaloneLinux;
                        }
                        else if (m_Architecture == StandaloneArchitecture.x86_64)
                        {
                            return BuildTarget.StandaloneLinux64;
                        }
                        else
                        {
                            return BuildTarget.StandaloneLinuxUniversal;
                        }
                    default:
                        if (m_Architecture == StandaloneArchitecture.x86_64)
                        {
                            return BuildTarget.StandaloneWindows;
                        }
                        else
                        {
                            return BuildTarget.StandaloneWindows64;
                        }
                }
            }
        }




        protected override void Reset()
        {
            switch (Application.platform)
            {
#if UNITY_5_5_OR_NEWER
                case RuntimePlatform.LinuxEditor:
                    m_TargetPlatform = StandalonePlatform.Linux;
                    break;
#endif
                case RuntimePlatform.OSXEditor:
                    m_TargetPlatform = StandalonePlatform.MacOS;
                    break;
                default:
                    m_TargetPlatform = StandalonePlatform.Windows;
                    break;
            }

            m_Architecture = StandaloneArchitecture.Universal;

            base.Reset();
        }
    }
}