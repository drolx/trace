import { Entity, Column } from 'typeorm';
import { TagEntity } from './base.tag.entity';
import { UserType } from './enum.user';

@Entity({ name: 'payment_types' })
export class PaymentType extends TagEntity {
  @Column({ default: false })
  public default: boolean;

  @Column({ type: 'varchar', length: 128, nullable: false })
  public name: string;

  @Column({ type: 'text', nullable: true })
  public description!: string;

  @Column({
    type: 'enum',
    enum: UserType,
    default: [UserType.ALL],
    array: true,
  })
  public userTypes: UserType[];
}
