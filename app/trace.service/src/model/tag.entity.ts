import { Column, Entity, Tree, TreeChildren, TreeParent } from 'typeorm';
import { BaseTimedEntity } from './base.timed.entity';

@Entity({ name: 'tags' })
@Tree('materialized-path')
export class Tag extends BaseTimedEntity {
  @Column({ type: 'varchar', length: 255 })
  public name: string;

  @TreeParent()
  public parent: Tag;

  @TreeChildren()
  public children: Tag[];

  @Column({ type: 'text', nullable: true })
  public description!: string;
}
