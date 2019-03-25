﻿
using UnityEngine;

namespace ETModel
{
    [ObjectSystem]
    public class BulletFlyAwakeSystem : AwakeSystem<BulletFlyComponent>
    {
        public override void Awake(BulletFlyComponent self)
        {
            self.Awake();
        }
    }

    [ObjectSystem]
    public class BulletFlyStartSystem : StartSystem<BulletFlyComponent>
    {
        public override void Start(BulletFlyComponent self)
        {
            self.Start();
        }
    }

    [ObjectSystem]
    public class BulletFlyUpdateSystem : UpdateSystem<BulletFlyComponent>
    {
        public override void Update(BulletFlyComponent self)
        {
            self.Update();
        }
    }

    public class BulletFlyComponent : Component 
    {
        private Bullet m_bullet;

        private float speed = 100f;

        private float maxLiftTime = 2f;

        private float instantiateTime = 0f;

        private SphereCollider m_collider;


        public void Awake()
        {
            this.m_bullet = this.GetParent<Bullet>();
            this.instantiateTime = Time.time;
            this.m_collider = this.m_bullet.GameObject.GetComponent<SphereCollider>();
        }

        public void Start()
        {


        }

        public void Update()
        {
            this.m_bullet.GameObject.transform.position += this.m_bullet.GameObject.transform.forward * this.speed * Time.deltaTime;

             if(Time.time - this.instantiateTime > this.maxLiftTime)
                 this.m_bullet.Dispose();
        }

        public void OnCollisionEnter(Collision collision)
        {
            //Log.Info($"撞到了{collision.collider.transform.gameObject.name}");
            //Log.Info($"销毁子弹");


            // 创建爆炸效果


            this.m_bullet.Dispose();

        }

        // private void OnCollision()
        // {
        //     Ray ray = new Ray();
        //
        //     ray.origin = this.m_collider.gameObject.transform.position;
        //
        //     ray.direction = this.m_collider.gameObject.transform.forward;
        //     
        //
        //     if (this.m_collider.Raycast(ray, out RaycastHit hit, this.m_collider.radius))
        //     {
        //         Log.Info($"方向前 子弹碰撞物体 = {hit.transform.gameObject.name}");
        //         return;
        //     }
        //     
        //     ray.direction = -this.m_collider.gameObject.transform.up;
        //
        //     if (this.m_collider.Raycast(ray, out hit, this.m_collider.radius))
        //     {
        //         Log.Info($"方向下 子弹碰撞物体 = {hit.transform.gameObject.name}");
        //         return;
        //     }
        //
        //     ray.direction = this.m_collider.gameObject.transform.up;
        //
        //     if (this.m_collider.Raycast(ray, out hit, this.m_collider.radius))
        //     {
        //         Log.Info($"方向上 子弹碰撞物体 = {hit.transform.gameObject.name}");
        //         return;
        //     }
        // }
    }
}