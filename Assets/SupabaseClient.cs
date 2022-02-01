using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupabaseClient : MonoBehaviour
{
    [SerializeField] private string supabaseUrl;
    [SerializeField] private string supabaseKey;

    private async void Awake()
    {
        await Supabase.Client.InitializeAsync(supabaseUrl, supabaseKey);
    }
}
