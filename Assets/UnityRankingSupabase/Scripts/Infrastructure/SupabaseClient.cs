using Supabase;
using UnityEngine;

namespace UnityRankingSupabase.Scripts.Infrastructure
{
    public class SupabaseClient : MonoBehaviour
    {
        [SerializeField] private string supabaseUrl;
        [SerializeField] private string supabaseKey;

        private void Awake()
        {
            Client.Initialize(supabaseUrl, supabaseKey);
        }
    }
}